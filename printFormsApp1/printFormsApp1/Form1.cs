#define IDEA2

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using AutoCAD;
using Autodesk;
//using Autodesk.AutoCAD.Interop;          // CAD 2010 以下版本
//using Autodesk.AutoCAD.Interop.Common;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using PRINTER;
using GetInstallPath;
using pmpGenerator;

namespace printFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();       
        }
        AcadApplication app1;
        AcadApplication app2;
        Thread t1;
        Thread t2;
        private void Form1_Load(object sender, EventArgs e)
        {           
            //初始化打印机列表
            comboBox_printerlist.Items.Add("DWG To PDF.pc3");
            comboBox_printerlist.Items.Add("PublishToWeb JPG.pc3");
            comboBox_printerlist.Items.Add("PublishToWeb PNG.pc3");
            comboBox_printerlist.SelectedIndex = 0;

            //初始化纸张，从数据库获取
            Init_PaperSizeList_FromDB();
            app1 = NewCAD();
            app2 = NewCAD();
            
            t1 = new Thread(Thread_print1);
            t1.Start();

            t2 = new Thread(Thread_print2);
            t2.Start();
            
        }


        /// <summary>
        /// 新建AutoCAD进程
        /// </summary>
        /// <returns></returns>
        private static AcadApplication NewCAD()
        {
            AcadApplication app=null;
            bool flag = false;
            while (app == null)
            {
                try
                {
                    app = new AcadApplicationClass();

                }
                catch { }
            }
            while (!flag)
            {

                try
                {
                    app.Visible = false;
                    app.ActiveDocument.Close();
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
            }
            return app;
        }

        /// <summary>
        /// 初始化纸张列表，纸张信息来自数据库
        /// </summary>
        private void Init_PaperSizeList_FromDB()
        {
            comboBox_PaperSizeList.Items.Clear();
            DB.BLL.PAPER_SIZE bll = new DB.BLL.PAPER_SIZE();
            DataSet papers_list = bll.GetList("1=1");
            DataTable a = papers_list.Tables[0];
            foreach (DataRow m in a.Rows)
            {
                comboBox_PaperSizeList.Items.Add(m.ItemArray[1]);
            }
            if (0 != comboBox_PaperSizeList.Items.Count)
            {
                comboBox_PaperSizeList.SelectedIndex = 0;
            }
        }
        //public int progressNum = 0;

#if IDEA1
        private class ProgressNum {
            public int num { get; set; } = 0;            
        }

        ProgressNum progressNum = new ProgressNum();
        /// <summary>
        /// 方案一：每次分配任务打开一个cad，任务结束停止cad
        /// </summary>
        
        private void thread_manager()
        {
            //progressNum.num = 0;
            //AcadApplication app1;
            //app1 = NewCAD();
            while (true)
            {
                bool progress_islock = false;
                while(!progress_islock){
                    try
                    {
                        progress_islock = Monitor.TryEnter(progressNum);
                        if (progress_islock)
                        {
                            if (progressNum.num < 1)
                            {
                                bool queue_islock = false;
                                while (!queue_islock)
                                {
                                    try
                                    {
                                        queue_islock = Monitor.TryEnter(queue);
                                        if (queue_islock)
                                        {
                                            if (0 != queue.Count)
                                            {
                                                mulInfo task = (mulInfo)queue.Dequeue();
                                                ParameterizedThreadStart test = new ParameterizedThreadStart(Thread_print);
                                                Thread a = new Thread(test);
                                                a.Start(task);
                                            }
                                            Monitor.Exit(queue);
                                        }
                                    }
                                    catch { }
                                }
                            }
                            Monitor.Exit(progressNum);
                            Thread.Sleep(500);
                        }
                    }
                    catch { }
                }
            }
        }
#endif
        // Queue<Object> queue = new Queue<object>();

        
        
        private void button_print_Click(object sender, EventArgs e)
        {
            
            DB.BLL.TASK bll_Task = new DB.BLL.TASK();
            DB.Model.TASK model_Task = new DB.Model.TASK();
            MessageForm fm = new MessageForm(fPrintNames.Count());
            fm.Show(this);                  //防止用户点击两次，重复加入任务
            int i = 0;
            foreach(string tem in fPrintNames)
            {
                i++;
                Thread.Sleep(30);
                model_Task.FILE_FULLNAME = tem;
                model_Task.TASK_GUID = System.Guid.NewGuid().ToString();
                model_Task.SAVE_PATH = textBox_TargetAddr.Text;
                model_Task.PRINTER = comboBox_printerlist.Text;
                model_Task.PAPER = comboBox_PaperSizeList.Text;
                model_Task.ORDERED = 0;
                model_Task.ISPRINTING = 0;
                model_Task.PRINTING_TIME = System.DateTime.Now;
                bll_Task.Add(model_Task);
                fm.setPos(i);
            }
            Thread.Sleep(1000);
            fm.Close();
            
        }

        /// <summary>
        /// 包含打印选项的类
        /// </summary>
        private class mulInfo{
            public string[] Files { set; get; }
            public string SaveAddr { set; get; }
            public string Selected_Printer { set; get; }
            public string Selected_Paper { set; get; }
            
        }
#if IDEA1
        /// <summary>
        /// 打印线程，可传入参数
        /// </summary>
        /// <param name="obj"></param>
        private void Thread_print(object obj)
        {
            bool islock = false;
            while (!islock)
            {
                try
                {
                    islock = Monitor.TryEnter(progressNum);
                    if (islock)
                    {
                        progressNum.num++;
                        Monitor.Exit(progressNum);
                    }
                }
                catch { }
            }
            AcadDocument drawing=null;
                        
            mulInfo str=(mulInfo)obj;
            AcadApplication app = NewCAD();

            string[] PrintNames_inThread = str.Files; 
            foreach (string fname in PrintNames_inThread)
            {
                bool isFinish = false;
                while (!isFinish)
                {
                    try
                    {                        
                        app.Documents.Open(fname,true);
                        isFinish = true;
                    }
                    catch
                    {
                        isFinish = false;
                    }
                }
                //防止AutoCAD响应慢，上一步还未响应程序就开始下一步命令，不断try直到成功执行

                isFinish = false;
                while (!isFinish)
                {
                    try
                    { drawing = app.ActiveDocument; isFinish = true; }
                    catch
                    { isFinish = false; }
                }
                isFinish = false;
                while (!isFinish)
                {
                    try
                    {
                        drawing.SetVariable("BACKGROUNDPLOT", 0);
                        drawing.ActiveLayout.CenterPlot = true;//居中
                        drawing.ActiveLayout.ConfigName = str.Selected_Printer;
                        
                        drawing.ActiveLayout.UseStandardScale = true;
                        drawing.ActiveLayout.StandardScale = AcPlotScale.acScaleToFit;
                        drawing.ActiveLayout.PlotType = AcPlotType.acExtents;
                        drawing.ActiveLayout.CanonicalMediaName = str.Selected_Paper;
                        isFinish = true;
                    }
                    catch
                    { isFinish = false; }
                }
        #region 截取文件名
                string[] dwgFullName = fname.Split('\\');
                string[] dwgName = dwgFullName[dwgFullName.Length - 1].Split('.');
                string pureName = null;
                for (int i = 0; i < dwgName.Length - 2; i++)
                {
                    pureName += dwgName[i];
                    pureName += ".";
                }

                pureName += dwgName[dwgName.Length - 2];
                string SaveFileName = str.SaveAddr + "/" + pureName;
                //drawing.SaveAs("C:/Users/JabinGuo/Desktop/convert", AcSaveAsType.ac2007_dxf);
        #endregion
                islock = false;
                while (!islock)
                {
                    try
                    {
                        islock = Monitor.TryEnter(drawing);
                    }
                    catch {
                        //此处测试过exception
                    }
                }
                bool isfinish = false;
                while (!isfinish)
                {
                    try
                    {
                        isfinish = drawing.Plot.PlotToFile(SaveFileName);
                        
                    }
                    catch  {  }
                }
                Monitor.Exit(drawing);
                drawing.Close(false);
                
            }
            app.Quit();
            islock = false;
                while (!islock)
                {
                    try
                    {
                        islock = Monitor.TryEnter(progressNum);
                        if (islock)
                        {
                            progressNum.num--;                            
                        }
                    }
                    catch (Exception e) { MessageBox.Show(e.Message); }
                }Monitor.Exit(progressNum);
            
            return;
            //button_FindFile.Enabled = true;
        }
#endif

#if IDEA2
        
        int TaskFlag=2;
        private void Thread_print1()
        {
            AcadDocument drawing = null;

            

            bool islock = false;
            //mulInfo TaskInfo;
            DB.BLL.TASK bll_Task = new DB.BLL.TASK();
            while (true)
            {
                if (0 < bll_Task.GetModelList("1=1").Count)//判断任务列表是否为空
                {
                    if (TaskFlag == 2)
                    {
                        TaskFlag = 0;
                    }
                    DB.Model.TASK model_Task;
                    if (0 < bll_Task.GetModelList("ISPRINTING=0").Count )//判断是否有未进行的打印任务
                    {
                        try
                        {
                            model_Task = bll_Task.GetModelList("ISPRINTING=0")[0];
                        }
                        catch { continue; }
                        if (0 == model_Task.ORDERED)//如果此任务没有被预约，先预约此任务，此次循环并不开始打印，这是为了防止多个cad进程同时打印一个任务
                        {
                            model_Task.ORDERED = 1;
                            bll_Task.Update(model_Task);
                        }
                        else if (1 == model_Task.ORDERED)//如果此任务已经被预约，且预约者是进程1，那么开始打印任务
                        {
                            model_Task.ISPRINTING = 1;
                            model_Task.PRINTING_TIME = System.DateTime.Now;
                            bll_Task.Update(model_Task);
                            string fname = model_Task.FILE_FULLNAME;
                            bool isFinish = false;
                            while (!isFinish)
                            {
                                try
                                {
                                    app1.Documents.Open(fname, true);
                                    
                                    isFinish = true;
                                }
                                catch
                                {
                                    isFinish = false;
                                }
                            }
                            //防止CAD反应慢，上一步任务未完成就开始了下一步命令
                            //List<DB.Model.TASK> model_Task = bll_Task.GetModelList("1=1");

                            isFinish = false;
                            while (!isFinish)
                            {
                                try
                                {
                                    drawing = app1.ActiveDocument; isFinish = true;
                                }
                                catch
                                {
                                    isFinish = false;
                                }
                            }
                            isFinish = false;
                            while (!isFinish)
                            {
                                try
                                {
                                    drawing.SetVariable("BACKGROUNDPLOT", 0);
                                    drawing.ActiveLayout.CenterPlot = true;//居中
                                    drawing.ActiveLayout.ConfigName = model_Task.PRINTER;
                                    drawing.ActiveLayout.PlotRotation = AcPlotRotation.ac0degrees;
                                    drawing.ActiveLayout.UseStandardScale = true;
                                    drawing.ActiveLayout.StandardScale = AcPlotScale.acScaleToFit;
                                    drawing.ActiveLayout.PlotType = AcPlotType.acExtents;
                                    drawing.ActiveLayout.CanonicalMediaName = model_Task.PAPER;
                                    
                                    isFinish = true;
                                }
                                catch
                                {
                                    isFinish = false;
                                }
                            }
                            #region 截取文件名
                            string[] dwgFullName = fname.Split('\\');
                            string[] dwgName = dwgFullName[dwgFullName.Length - 1].Split('.');
                            string pureName = null;
                            for (int i = 0; i < dwgName.Length - 2; i++)
                            {
                                pureName += dwgName[i];
                                pureName += ".";
                            }

                            pureName += dwgName[dwgName.Length - 2];
                            string SaveFileName = model_Task.SAVE_PATH + "/" + pureName;
                            //drawing.SaveAs("C:/Users/JabinGuo/Desktop/convert", AcSaveAsType.ac2007_dxf);
                            #endregion
                            islock = false;
                            while (!islock)
                            {
                                try
                                {
                                    islock = Monitor.TryEnter(drawing);
                                }
                                catch
                                {
                                   
                                }
                            }
                            bool isfinish = false;
                            while (!isfinish)
                            {
                                try
                                {
                                    isfinish = drawing.Plot.PlotToFile(SaveFileName);
                                }
                                catch { }
                            }
                            Monitor.Exit(drawing);
                            drawing.Close(false);
                            bll_Task.Delete(model_Task.TASK_GUID);
                        }
                    } 
                    if (0 < bll_Task.GetModelList("ISPRINTING!=0").Count)//如果长时间没有完成打印任务，说明cad卡死，关闭此进程并重新打开
                    {
                        try
                        {
                            model_Task = bll_Task.GetModelList("ISPRINTING!=0")[0];
                        }
                        catch { continue; }
                        if (2 < System.DateTime.Now.Subtract((DateTime)model_Task.PRINTING_TIME).Minutes)
                        {
                            switch (model_Task.ISPRINTING)
                            {
                                case 1:
                                    try
                                    {
                                        app1.Quit();
                                        
                                    }catch/*(Exception e) */{ /*MessageBox.Show(e.ToString());*/ }
                                    Thread.Sleep(2000);
                                    app1 = NewCAD();
                                    break;
                                case 2:
                                    try
                                    {
                                        //app2.ActiveDocument.Close(false);
                                        app2.Quit();
                                    }catch/*(Exception e)*/ { /*MessageBox.Show(e.ToString());*/ }
                                    Thread.Sleep(2000);
                                    app2 = NewCAD();
                                    break;
                                default:
                                    MessageBox.Show("找不到打印{0}的进程", model_Task.FILE_FULLNAME);
                                    break;
                            }
                            model_Task.ORDERED = 0;
                            model_Task.ISPRINTING = 0;
                            model_Task.PRINTING_TIME = System.DateTime.Now;
                            bll_Task.Update(model_Task);
                        }
                    }                   
                }
                else
                {
                    if (0 == TaskFlag)
                    {
                        MessageBox.Show("打印完成");
                        TaskFlag = 1;
                    }
                    if (1 == TaskFlag)
                    {
                        TaskFlag = 2;
                    }
                    continue;
                }
            }
        }

        private void Thread_print2()
        {
            AcadDocument drawing = null;
            bool islock = false;
            
            DB.BLL.TASK bll_Task = new DB.BLL.TASK();
            while (true)
            {
                if (0 < bll_Task.GetModelList("1=1").Count)
                {
                    if (TaskFlag == 2)
                    {
                        TaskFlag = 0;
                    }
                    DB.Model.TASK model_Task;
                    if (0 < bll_Task.GetModelList("ISPRINTING=0").Count)
                    {
                        try
                        {
                            model_Task = bll_Task.GetModelList("ISPRINTING=0")[0];
                        }
                        catch { continue; }
                        if (0 == model_Task.ORDERED)
                        {
                            model_Task.ORDERED = 2;
                            bll_Task.Update(model_Task);
                        }
                        else if (2 == model_Task.ORDERED)
                        {
                            model_Task.ISPRINTING = 2;
                            model_Task.PRINTING_TIME = System.DateTime.Now;
                            bll_Task.Update(model_Task);
                            string fname = model_Task.FILE_FULLNAME;
                            bool isFinish = false;
                            while (!isFinish)
                            {
                                try
                                {
                                    app2.Documents.Open(fname, true);
                                    isFinish = true;
                                }
                                catch
                                {
                                    isFinish = false;
                                }
                            }
                            //防止CAD反应慢，上一步任务未完成就开始了下一步命令
                            
                            isFinish = false;
                            while (!isFinish)
                            {
                                try
                                {
                                    drawing = app2.ActiveDocument; isFinish = true;
                                }
                                catch
                                {
                                    isFinish = false;
                                }
                            }
                            isFinish = false;
                            while (!isFinish)
                            {
                                try
                                {
                                    drawing.SetVariable("BACKGROUNDPLOT", 0);
                                    drawing.ActiveLayout.CenterPlot = true;//居中
                                    drawing.ActiveLayout.ConfigName = model_Task.PRINTER;
                                    drawing.ActiveLayout.PlotRotation = AcPlotRotation.ac0degrees;
                                    drawing.ActiveLayout.UseStandardScale = true;
                                    drawing.ActiveLayout.StandardScale = AcPlotScale.acScaleToFit;
                                    drawing.ActiveLayout.PlotType = AcPlotType.acExtents;
                                    drawing.ActiveLayout.CanonicalMediaName = model_Task.PAPER;
                                    isFinish = true;
                                }
                                catch
                                {
                                    isFinish = false;
                                }
                            }
                            #region 截取文件名
                            string[] dwgFullName = fname.Split('\\');
                            string[] dwgName = dwgFullName[dwgFullName.Length - 1].Split('.');
                            string pureName = null;
                            for (int i = 0; i < dwgName.Length - 2; i++)
                            {
                                pureName += dwgName[i];
                                pureName += ".";
                            }

                            pureName += dwgName[dwgName.Length - 2];
                            string SaveFileName = model_Task.SAVE_PATH + "/" + pureName;
                            #endregion
                            islock = false;
                            while (!islock)
                            {
                                try
                                {
                                    islock = Monitor.TryEnter(drawing);
                                }
                                catch
                                {
                                    
                                }
                            }
                            bool isfinish = false;
                            while (!isfinish)
                            {
                                try
                                {
                                    isfinish = drawing.Plot.PlotToFile(SaveFileName);
                                }
                                catch { }
                            }
                            Monitor.Exit(drawing);
                            drawing.Close(false);
                            bll_Task.Delete(model_Task.TASK_GUID);
                        }
                    }
                    if (0 < bll_Task.GetModelList("ISPRINTING!=0").Count)
                    {
                        try
                        {
                            model_Task = bll_Task.GetModelList("ISPRINTING!=0")[0];
                        }
                        catch { continue; }
                        if (2 < System.DateTime.Now.Subtract((DateTime)model_Task.PRINTING_TIME).Minutes)
                        {
                            switch (model_Task.ISPRINTING)
                            {
                                case 1:
                                    try
                                    {
                                        app1.Quit();
                                        
                                    }
                                    catch /*(Exception e) */{ /*MessageBox.Show(e.ToString());*/ }
                                    Thread.Sleep(2000);
                                    app1 = NewCAD();
                                    break;
                                case 2:
                                    try
                                    {
                                        app2.Quit();
                                    }
                                    catch/* (Exception e) */{/* MessageBox.Show(e.ToString()); */}
                                    Thread.Sleep(2000);
                                    app2 = NewCAD();
                                    break;
                                default:
                                    MessageBox.Show("找不到打印{0}的进程", model_Task.FILE_FULLNAME);
                                    break;
                            }

                            model_Task.ORDERED = 0;
                            model_Task.ISPRINTING = 0;
                            model_Task.PRINTING_TIME = System.DateTime.Now;
                            bll_Task.Update(model_Task);
                        }
                    }
                }
                else
                {
                    
                    continue;
                }
            }
        }
        
#endif
        private void button_runCAD_Click(object sender, EventArgs e)
        {
            string FileName = textBox_TargetAddr.Text + "/" + "压力测试";
            int i = 0;
            DateTime StartTime = System.DateTime.Now;
            DateTime EndTime;
            TimeSpan TotalTime;

      }

        private void comboBox_printerlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
#if true
        /// <summary>
        /// 添加纸张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AddPaper_Click(object sender, EventArgs e)
        {
            if (textBox_PaperName.Text == "" || textBox_userdef_printlen.Text == "" || textBox_userdef_printwidth.Text == "")
            {
                MessageBox.Show("请先完成纸张定义");
                return;
            }

            //写入数据库
            DB.BLL.PAPER_SIZE bll = new DB.BLL.PAPER_SIZE();
            DB.Model.PAPER_SIZE model = new DB.Model.PAPER_SIZE();
            model.GUID = System.Guid.NewGuid().ToString();
            model.PAPER_NAME = textBox_PaperName.Text;

            if (checkBox_unit.Checked)
            {
                
                model.PAPER_LENGTH = Convert.ToDecimal(textBox_userdef_printlen.Text);
                model.PAPER_WIDTH = Convert.ToDecimal(textBox_userdef_printwidth.Text);
                model.PAPER_PIXEL_LENGTH = Convert.ToDecimal(Math.Ceiling((Convert.ToDouble(textBox_userdef_printlen.Text)) * 37.8));//根据厘米长度计算像素
                model.PAPER_PIXEL_WIDTH = Convert.ToDecimal(Math.Ceiling((Convert.ToDouble(model.PAPER_WIDTH)) * 37.8));
                bll.Add(model);
            }
            else
            {
                model.PAPER_LENGTH = Convert.ToDecimal(Convert.ToDouble(textBox_userdef_printlen.Text) * 2.54 / 96);
                model.PAPER_WIDTH = Convert.ToDecimal(Convert.ToDouble(textBox_userdef_printwidth.Text) * 2.54 / 96);
                model.PAPER_PIXEL_LENGTH = Convert.ToDecimal(textBox_userdef_printlen.Text);
                model.PAPER_PIXEL_WIDTH = Convert.ToDecimal(textBox_userdef_printwidth.Text);
                bll.Add(model);
            }
                              
            Init_dgv_PaperSizeList();

            //将纸张信息添加进pmp文件
            SavePaper();
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t1.Abort();
            t2.Abort();
            try
            {
                app1.Quit();
                app2.Quit();
            }
            catch { }
        }

        private void 选择要打印的文件(object sender, EventArgs e)
        {

        }
        string[] fPrintNames=null;
        private void button_FindFile_Click(object sender, EventArgs e)
        {
            fPrintNames = null;
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog
            {
                AutoUpgradeEnabled = false,//OpenFileDialog会卡顿,用这个就好了
                Filter = "所有文件(*.*)|*.*|dwg文件(*.dwg)|*.dwg",
                Multiselect = true,//允许同时选择多个文件
                InitialDirectory = "c:\\",//注意这里写路径时要用c:\\而不是c:\
        };
            
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                
                    fPrintNames = openFileDialog.FileNames;             
                    textBox_File2Print.Text = fPrintNames[0];
                }            
  
            try
            {
                if (fPrintNames != null)
                {
                    button_print.Enabled = true;                    
                }
            }
            catch { MessageBox.Show("选择文件失败"); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                Init_dgv_PaperSizeList();
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                Init_PaperSizeList_FromDB();
            }
        }
        /// <summary>
        /// 初始化DataGridView，数据来自数据库 
        /// </summary>
        private void Init_dgv_PaperSizeList()
        {
            DB.BLL.PAPER_SIZE papers = new DB.BLL.PAPER_SIZE();
            DataSet papers_list = papers.GetList("1=1");
            
            dgv_PaperSizeList.DataSource = papers_list.Tables[0];
            dgv_PaperSizeList.RowHeadersVisible = false;
            dgv_PaperSizeList.Columns[0].Visible = false;
            dgv_PaperSizeList.Columns[1].HeaderCell.Value = "纸张名称";
            dgv_PaperSizeList.Columns[2].HeaderCell.Value = "纸张长度/厘米";
            dgv_PaperSizeList.Columns[3].HeaderCell.Value = "纸张宽度/厘米";
            dgv_PaperSizeList.Columns[4].HeaderCell.Value = "纸张长度/像素";
            dgv_PaperSizeList.Columns[5].HeaderCell.Value = "纸张宽度/像素";
            dgv_PaperSizeList.Columns[1].Width = dgv_PaperSizeList.Width / 5;
            dgv_PaperSizeList.Columns[2].Width = dgv_PaperSizeList.Width / 5;
            dgv_PaperSizeList.Columns[3].Width = dgv_PaperSizeList.Width / 5;
            dgv_PaperSizeList.Columns[4].Width = dgv_PaperSizeList.Width / 5;
            dgv_PaperSizeList.Columns[5].Width = dgv_PaperSizeList.Width / 5;
        }
        private void comboBox_PrinterNeedAdd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_PaperSizeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_PaperSizeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            

        }

        /// <summary>
        /// 选择保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_TargetAddr_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string SavePath = fbd.SelectedPath;
                textBox_TargetAddr.Text = SavePath;
            }
        }


        private void button_SavePaper_Click(object sender, EventArgs e)
        {

            SavePaper();

        }

        private void SavePaper()
        {
            
            //从注册表寻找pmp文件的位置
            string keyPath = @"Software\Autodesk\AutoCAD\R22.0\ACAD-1001:804";
            string keyName = "RoamableRootFolder";
            object FindPC3_Path = RegistryHelpers.GetRegistryValue(keyPath, keyName);
            string pmp_path = (string)FindPC3_Path + "Plotters\\PMP Files\\";

            PrinterSetting paper = new PrinterSetting();

            DB.BLL.PAPER_SIZE papers = new DB.BLL.PAPER_SIZE();
            DataSet papers_list = papers.GetList("1=1");
            DataTable row = papers_list.Tables[0];
            foreach (DataGridViewRow r in dgv_PaperSizeList.Rows)
            {
                paper.PaperX = Convert.ToDouble(r.Cells[2].Value) * 10;
                paper.PaperY = Convert.ToDouble(r.Cells[3].Value) * 10;
                paper.userdef_name = (string)r.Cells[1].Value;

                //三个打印机，添加三次
                paper.AddPrinter(pmp_path + "DWG To PDF.pmp");
                paper.AddPrinter(pmp_path + "PublishToWeb JPG.pmp");
                paper.AddPrinter(pmp_path + "PublishToWeb PNG.pmp");
            }
        }

        private void button_DeletPaper_Click(object sender, EventArgs e)
        {
            //从注册表寻找pmp文件位置
            string keyPath = @"Software\Autodesk\AutoCAD\R22.0\ACAD-1001:804";
            string keyName = "RoamableRootFolder";

            object FindPC3_Path = RegistryHelpers.GetRegistryValue(keyPath, keyName);
            string pmp_path = (string)FindPC3_Path + "Plotters\\PMP Files\\";
            //从数据库删除
            DB.BLL.PAPER_SIZE bll = new DB.BLL.PAPER_SIZE();
            
            DataGridViewSelectedRowCollection rows = dgv_PaperSizeList.SelectedRows;
            foreach(DataGridViewRow r in rows)
            {
                string PAPER_NAME = (string)r.Cells[1].Value;
                bll.Delete(PAPER_NAME);
                //删除纸张
            
                PrinterTool.RemovePrinters(pmp_path + "DWG To PDF.pmp", new string[] { PAPER_NAME });
                PrinterTool.RemovePrinters(pmp_path + "PublishToWeb JPG.pmp", new string[] { PAPER_NAME });
                PrinterTool.RemovePrinters(pmp_path + "PublishToWeb PNG.pmp", new string[] { PAPER_NAME });
            }
            
            Init_dgv_PaperSizeList();
            
        }

        private void textBox_File2Print_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton_unit_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox_unit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_unit.Checked)
            {
                label6.Text = "厘米";
                label7.Text = "厘米";
            }
            else
            {
                label6.Text = "像素";
                label7.Text = "像素";
            }
        }
    }
#endif
        }
