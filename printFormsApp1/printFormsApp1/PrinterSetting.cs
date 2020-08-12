using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Printers;
using PiaNO;
using PRINTER;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
namespace PRINTER
{
    public class PrinterSetting
    {
        public double PaperX = 0;
        public double PaperY = 0;
        public string userdef_name = "";
        double Offset_Left = 0;
        double Offset_Down = 0;
        private string Name;
        private string Media_description_name;
        PlotterConfiguration PdfConfig = null;
        //节点名称-纸张中英对换表
        private const string str_size = "size";
        //节点名称-纸张边界信息
        private const string str_description = "description";

        public PlotterConfiguration AddPrinter(string pmp_FullPath/*,double PaperX,double PaperY*/)
        {


            Name = userdef_name; 
                //$"JBS_PDF_({PaperY.ToString("#0.00")}_x_{PaperX.ToString("#0.00")}_MM)";//纸张名称

            // JoinBoxStandard 嘻嘻
            //                                                              (5,_17)这个是默认偏移量
            // media_description_name="ISO_A0_Portrait_841.00W_x_1189.00H_-_(5,_17)_x_(836,_1172)_=959805_MM 
            //实际打印面积(虽然因为偏移值是0,等于长乘宽就可以,但是为了日后我忘记这里怎么算的,还是求一下吧)

            double area = (PaperY - (Offset_Left * 2)) * (PaperX - (Offset_Down * 2));

            //如果没有小数点保留,可能cad闪退!
            StringBuilder description_name = new StringBuilder();

            description_name.Append($"JBS_PDF_Portrait_{PaperY.ToString("#0.00")}W_x_{PaperX.ToString("#0.00")}H");
            description_name.Append("_-_");
            description_name.Append($"({Offset_Left.ToString("#0.00")},_{Offset_Down.ToString("#0.00")})");//偏移量
            description_name.Append("_x_");
            description_name.Append($"({(PaperY - Offset_Left).ToString("#0.00")},_{(PaperX - Offset_Down).ToString("#0.00")})_");
            description_name.Append($"={area.ToString("#0.00")}_MM");

            //Media_description_name = description_name.ToString();
            Media_description_name = Name;

            PdfConfig = new PlotterConfiguration(pmp_FullPath)
            {
                TruetypeAsText = true
            };

            //解压了打印机信息之后,遍历打印机节点  
            foreach (var nodeA in PdfConfig)
            {
                if (nodeA.NodeName == "udm")
                {
                    foreach (var nodeB in nodeA)
                    {
                        if (nodeB.NodeName == "media")
                        {
                            PiaNode piaNode_size = null;
                            PiaNode piaNode_description = null;

                            //遍历是否有节点
                            foreach (PiaNode nodeC in nodeB)
                            {
                                string nden = nodeC.NodeName;
                                switch (nden)
                                {
                                    case str_size:
                                        piaNode_size = nodeC;
                                        break;
                                    case str_description:
                                        piaNode_description = nodeC;
                                        break;
                                }
                            }
                            //找不到就添加节点
                            if (piaNode_size == null)
                            {
                                piaNode_size = nodeB.Add(str_size);
                            }
                            if (piaNode_description == null)
                            {
                                piaNode_description = nodeB.Add(str_description);
                            }
                            //在节点中添加/修改信息
                            AddPaperEnAndCn(piaNode_size);
                            AddPaperDescription(piaNode_description);
                            break;
                        }
                    }
                    break;
                }
            }
            PdfConfig.Saves();
            return PdfConfig;
        }
        //private string Localized_name = null;
        /// <summary>
        /// 添加pmp纸张-中英对换表
        /// </summary>
        /// <param name="nodeC"></param>
        private void AddPaperEnAndCn(PiaNode nodeC)
        {
            string Localized_name = userdef_name;
            //图纸数量+1就是新建一张图   
            var spl = '\n';
            int count = nodeC.Count();
            string name = count.ToString();
            string[] paper = new string[] {
                                name+ "{",
                                $"caps_type=2",             //1是系统的,2是用户的.这里严格,可不可以在打印纸看见就是这里了
                                $"name=\"{Name}",
                                $"localized_name=\"{Localized_name}",
                                $"media_description_name=\"{Media_description_name}",
                                $"media_group=15",          //4是系统的,15是用户的.15是以毫米为单位，16是以像素为单位
                                "landscape_mode=FALSE\n}",   //false是系统的,true是用户的
                                };
            string paperAll = string.Join(spl + " ", paper) + spl;
            PlusNode(nodeC, name, paperAll);
        }

        /// <summary>
        /// 判断是否已有同名节点,有就不加入
        /// </summary>
        /// <param name="nodeC"></param>
        /// <param name="name"></param>
        /// <param name="paperAll"></param>
        private void PlusNode(PiaNode nodeC, string name, string paperAll)
        {
            bool yiyou = true;
            foreach (var nodeD in nodeC)
            {
                foreach (var pair in nodeD.Values)
                {
                    if (pair.Key == "media_description_name_str" &&
                        pair.Value == Media_description_name)
                    {
                        yiyou = false;
                        break;
                    }
                }
                if (!yiyou)
                {
                    break;
                }
            }
            if (yiyou)
            {
                nodeC.Add(name, paperAll);
            }
        }
        /// <summary>
        /// 添加pmp纸张-信息
        /// </summary>
        /// <param name="nodeC"></param>
        private void AddPaperDescription(PiaNode nodeC)
        {
            var spl = '\n';
            int count = nodeC.Count();
            string name = count.ToString();
            string[] paper = new string[] {
                               name + "{",
                               $"caps_type=2",  //1是系统的,2是用户的.这里严格,可不可以在打印纸看见就是这里了
                               $"name=\"{/*Media_description_name*/Name}",
                               $"media_bounds_urx={ChangDouble(PaperX)}",
                               $"media_bounds_ury={ChangDouble(PaperY)}",
                               $"printable_bounds_llx={ChangDouble(Offset_Left)}",
                               $"printable_bounds_lly={ChangDouble(Offset_Down)}",
                               $"printable_bounds_urx={ChangDouble(PaperX)}",
                               $"printable_bounds_ury={ChangDouble(PaperY)}",
                               $"printable_area={ChangDouble(PaperX * PaperY)}",
                               "dimensional=TRUE\n}",
                                };
            string paperAll = string.Join(spl + " ", paper) + spl;
            PlusNode(nodeC, name, paperAll);
        }
        /// <summary>
        /// 保证数字在12位内
        /// </summary>
        /// <param name="dos"></param>
        /// <returns></returns>
        string ChangDouble(double dos)
        {
            var str = string.Format("{0:0.0#########}", dos);
            if (str.Length >= 12)
            {
                return str.Substring(0, 12);
            }
            return str;
        }
    }

    public static class PrinterTool
    {
        /// <summary>
        /// 移除图纸 
        /// </summary> 
        /// <param name="pmp_FullPath">pmp名称</param>
        /// <param name="printerNames">要移除的纸张名称</param>
        public static void RemovePrinters(/*this Plot plot,*/ string pmp_FullPath, string[] printerNames/*, Database db, Transaction tr*/)
        {
            var pdfConfig = new PlotterConfiguration(pmp_FullPath)
            {
                TruetypeAsText = true
            };
            
            pdfConfig.RemovePrinters(printerNames);
            sortNodes(pdfConfig);
            pdfConfig.Saves();
        }

        /// <summary>
        /// 移除图纸 
        /// </summary> 
        /// <param name="pdfConfig">pmp的解析</param>
        /// <param name="printerNames">要移除的纸张名称</param>
        static void RemovePrinters(this PlotterConfiguration pdfConfig, string[] printerNames)
        {
            //解压了打印机信息之后,遍历打印机节点  
            foreach (var nodeA in pdfConfig)
            {
                if (nodeA.NodeName == "udm")
                {
                    foreach (var nodeB in nodeA)
                    {
                        if (nodeB.NodeName == "media")
                        {
                            //遍历是否有节点
                            foreach (PiaNode nodeC in nodeB)
                            {
                                switch (nodeC.NodeName)
                                {
                                    case "size":
                                    case "description":
                                        {
                                            nodeC.RemoveChildNodes(printerNames);
                                        }
                                        break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        static void sortNodes(PlotterConfiguration pdfConfig)
        {
            foreach (var nodeA in pdfConfig)
            {
                if (nodeA.NodeName == "udm")
                {
                    foreach (var nodeB in nodeA)
                    {
                        if (nodeB.NodeName == "media")
                        {
                            //遍历是否有节点
                            foreach (PiaNode nodeC in nodeB)
                            {
                                switch (nodeC.NodeName)
                                {
                                    case "size":
                                    case "description":
                                        {
                                            int i = 0;
                                           // int num = nodeC.ChildNodes.Count;
                                            foreach(PiaNode nondD in nodeC)
                                            {
                                                nondD.NodeName = i.ToString();
                                                i++;
                                            }
                                        }
                                        break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
