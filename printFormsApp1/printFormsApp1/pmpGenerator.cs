using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCAD;
using Autodesk;
using GetInstallPath;
using PiaNO;
using System.IO;

namespace pmpGenerator
{
    public class Pc3PmpChange
    {
        /// <summary>
        /// 附着pmp路径到pc3内
        /// </summary>
        /// <param name="plotDevice">当前调用的打印机</param>
        /// <param name="dwgtopdfpmp">pmp路径</param>
        public void ChangUserDefinedModel(string plotDevice, string dwgtopdfpmp)
        {
            //获取这个打印机的完整路径
            string keyPath = @"Software\Autodesk\AutoCAD\R22.0\ACAD-1001:804";
            string keyName = "RoamableRootFolder";

            object FindPC3_Path = RegistryHelpers.GetRegistryValue(keyPath, keyName);
            string printerConfigDir = FindPC3_Path + "Plotters\\" + plotDevice;
            var ns = new string[] { printerConfigDir, dwgtopdfpmp };

            foreach (var path in ns)
            {
                if (!File.Exists(path))
                {
                    continue;
                } 
                var PdfConfig = new PlotterConfiguration(path);
                //解压了打印机信息之后,遍历打印机节点
                foreach (var nodeA in PdfConfig)
                {
                    if (nodeA.NodeName == "meta")
                    {
                        nodeA.ValueChang("user_defined_model_pathname" + "_str", dwgtopdfpmp);
                        break;
                    }
                }
                PdfConfig.Saves();
            }

        }
    }
}