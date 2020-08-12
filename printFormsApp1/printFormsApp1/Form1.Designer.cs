namespace printFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_printerlist = new System.Windows.Forms.ComboBox();
            this.button_runCAD = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.textBox_userdef_printlen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_userdef_printwidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_PaperSizeList = new System.Windows.Forms.ComboBox();
            this.button_AddPaper = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PaperName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_FindFile = new System.Windows.Forms.Button();
            this.textBox_File2Print = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Print = new System.Windows.Forms.TabPage();
            this.button_TargetAddr = new System.Windows.Forms.Button();
            this.textBox_TargetAddr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Time = new System.Windows.Forms.TextBox();
            this.textBox_ImgNum = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_PaperSizeList = new System.Windows.Forms.DataGridView();
            this.button_DeletPaper = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_unit = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_Print.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaperSizeList)).BeginInit();
            this.SuspendLayout();
            // 
            // button_print
            // 
            this.button_print.Enabled = false;
            this.button_print.Location = new System.Drawing.Point(522, 326);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(91, 27);
            this.button_print.TabIndex = 0;
            this.button_print.Text = "打印";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择打印机";
            // 
            // comboBox_printerlist
            // 
            this.comboBox_printerlist.FormattingEnabled = true;
            this.comboBox_printerlist.Location = new System.Drawing.Point(168, 96);
            this.comboBox_printerlist.Name = "comboBox_printerlist";
            this.comboBox_printerlist.Size = new System.Drawing.Size(333, 23);
            this.comboBox_printerlist.TabIndex = 2;
            this.comboBox_printerlist.SelectedIndexChanged += new System.EventHandler(this.comboBox_printerlist_SelectedIndexChanged);
            // 
            // button_runCAD
            // 
            this.button_runCAD.Location = new System.Drawing.Point(64, 287);
            this.button_runCAD.Name = "button_runCAD";
            this.button_runCAD.Size = new System.Drawing.Size(80, 34);
            this.button_runCAD.TabIndex = 3;
            this.button_runCAD.Text = "压力测试";
            this.button_runCAD.UseVisualStyleBackColor = true;
            this.button_runCAD.Click += new System.EventHandler(this.button_runCAD_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(247, 312);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(67, 15);
            this.label.TabIndex = 4;
            this.label.Text = "自定义长";
            // 
            // textBox_userdef_printlen
            // 
            this.textBox_userdef_printlen.Location = new System.Drawing.Point(320, 309);
            this.textBox_userdef_printlen.Name = "textBox_userdef_printlen";
            this.textBox_userdef_printlen.Size = new System.Drawing.Size(100, 25);
            this.textBox_userdef_printlen.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "自定义宽";
            // 
            // textBox_userdef_printwidth
            // 
            this.textBox_userdef_printwidth.Location = new System.Drawing.Point(320, 357);
            this.textBox_userdef_printwidth.Name = "textBox_userdef_printwidth";
            this.textBox_userdef_printwidth.Size = new System.Drawing.Size(100, 25);
            this.textBox_userdef_printwidth.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "选择打印尺寸";
            // 
            // comboBox_PaperSizeList
            // 
            this.comboBox_PaperSizeList.FormattingEnabled = true;
            this.comboBox_PaperSizeList.Location = new System.Drawing.Point(168, 148);
            this.comboBox_PaperSizeList.Name = "comboBox_PaperSizeList";
            this.comboBox_PaperSizeList.Size = new System.Drawing.Size(333, 23);
            this.comboBox_PaperSizeList.TabIndex = 9;
            this.comboBox_PaperSizeList.SelectedIndexChanged += new System.EventHandler(this.comboBox_PaperSizeList_SelectedIndexChanged);
            // 
            // button_AddPaper
            // 
            this.button_AddPaper.Location = new System.Drawing.Point(120, 399);
            this.button_AddPaper.Name = "button_AddPaper";
            this.button_AddPaper.Size = new System.Drawing.Size(85, 29);
            this.button_AddPaper.TabIndex = 10;
            this.button_AddPaper.Text = "添加";
            this.button_AddPaper.UseVisualStyleBackColor = true;
            this.button_AddPaper.Click += new System.EventHandler(this.button_AddPaper_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "自定义纸张名称";
            // 
            // textBox_PaperName
            // 
            this.textBox_PaperName.Location = new System.Drawing.Point(320, 267);
            this.textBox_PaperName.Name = "textBox_PaperName";
            this.textBox_PaperName.Size = new System.Drawing.Size(100, 25);
            this.textBox_PaperName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "选择要打印的文件";
            // 
            // button_FindFile
            // 
            this.button_FindFile.Location = new System.Drawing.Point(511, 44);
            this.button_FindFile.Name = "button_FindFile";
            this.button_FindFile.Size = new System.Drawing.Size(84, 28);
            this.button_FindFile.TabIndex = 14;
            this.button_FindFile.Text = "浏览";
            this.button_FindFile.UseVisualStyleBackColor = true;
            this.button_FindFile.Click += new System.EventHandler(this.button_FindFile_Click);
            // 
            // textBox_File2Print
            // 
            this.textBox_File2Print.Location = new System.Drawing.Point(168, 47);
            this.textBox_File2Print.Name = "textBox_File2Print";
            this.textBox_File2Print.Size = new System.Drawing.Size(333, 25);
            this.textBox_File2Print.TabIndex = 15;
            this.textBox_File2Print.TextChanged += new System.EventHandler(this.textBox_File2Print_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Print);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 486);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_Print
            // 
            this.tabPage_Print.Controls.Add(this.button_TargetAddr);
            this.tabPage_Print.Controls.Add(this.textBox_TargetAddr);
            this.tabPage_Print.Controls.Add(this.label9);
            this.tabPage_Print.Controls.Add(this.textBox_Time);
            this.tabPage_Print.Controls.Add(this.textBox_ImgNum);
            this.tabPage_Print.Controls.Add(this.label1);
            this.tabPage_Print.Controls.Add(this.textBox_File2Print);
            this.tabPage_Print.Controls.Add(this.button_print);
            this.tabPage_Print.Controls.Add(this.button_FindFile);
            this.tabPage_Print.Controls.Add(this.comboBox_printerlist);
            this.tabPage_Print.Controls.Add(this.label5);
            this.tabPage_Print.Controls.Add(this.button_runCAD);
            this.tabPage_Print.Controls.Add(this.comboBox_PaperSizeList);
            this.tabPage_Print.Controls.Add(this.label3);
            this.tabPage_Print.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Print.Name = "tabPage_Print";
            this.tabPage_Print.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Print.Size = new System.Drawing.Size(796, 457);
            this.tabPage_Print.TabIndex = 0;
            this.tabPage_Print.Text = "打印";
            this.tabPage_Print.UseVisualStyleBackColor = true;
            // 
            // button_TargetAddr
            // 
            this.button_TargetAddr.Location = new System.Drawing.Point(511, 243);
            this.button_TargetAddr.Name = "button_TargetAddr";
            this.button_TargetAddr.Size = new System.Drawing.Size(84, 25);
            this.button_TargetAddr.TabIndex = 20;
            this.button_TargetAddr.Text = "浏览";
            this.button_TargetAddr.UseVisualStyleBackColor = true;
            this.button_TargetAddr.Click += new System.EventHandler(this.button_TargetAddr_Click);
            // 
            // textBox_TargetAddr
            // 
            this.textBox_TargetAddr.Location = new System.Drawing.Point(168, 243);
            this.textBox_TargetAddr.Name = "textBox_TargetAddr";
            this.textBox_TargetAddr.Size = new System.Drawing.Size(333, 25);
            this.textBox_TargetAddr.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "目标地址";
            // 
            // textBox_Time
            // 
            this.textBox_Time.Location = new System.Drawing.Point(64, 389);
            this.textBox_Time.Name = "textBox_Time";
            this.textBox_Time.Size = new System.Drawing.Size(100, 25);
            this.textBox_Time.TabIndex = 17;
            // 
            // textBox_ImgNum
            // 
            this.textBox_ImgNum.Location = new System.Drawing.Point(64, 347);
            this.textBox_ImgNum.Name = "textBox_ImgNum";
            this.textBox_ImgNum.Size = new System.Drawing.Size(100, 25);
            this.textBox_ImgNum.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox_unit);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.dgv_PaperSizeList);
            this.tabPage2.Controls.Add(this.button_DeletPaper);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBox_PaperName);
            this.tabPage2.Controls.Add(this.label);
            this.tabPage2.Controls.Add(this.textBox_userdef_printlen);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBox_userdef_printwidth);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button_AddPaper);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "添加纸张尺寸";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "已有纸张尺寸";
            // 
            // dgv_PaperSizeList
            // 
            this.dgv_PaperSizeList.AllowUserToAddRows = false;
            this.dgv_PaperSizeList.AllowUserToDeleteRows = false;
            this.dgv_PaperSizeList.AllowUserToResizeColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PaperSizeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_PaperSizeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PaperSizeList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_PaperSizeList.Location = new System.Drawing.Point(3, 30);
            this.dgv_PaperSizeList.MultiSelect = false;
            this.dgv_PaperSizeList.Name = "dgv_PaperSizeList";
            this.dgv_PaperSizeList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PaperSizeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_PaperSizeList.RowTemplate.Height = 27;
            this.dgv_PaperSizeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PaperSizeList.Size = new System.Drawing.Size(790, 217);
            this.dgv_PaperSizeList.TabIndex = 16;
            this.dgv_PaperSizeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PaperSizeList_CellContentClick);
            // 
            // button_DeletPaper
            // 
            this.button_DeletPaper.Location = new System.Drawing.Point(599, 399);
            this.button_DeletPaper.Name = "button_DeletPaper";
            this.button_DeletPaper.Size = new System.Drawing.Size(96, 29);
            this.button_DeletPaper.TabIndex = 15;
            this.button_DeletPaper.Text = "删除";
            this.button_DeletPaper.UseVisualStyleBackColor = true;
            this.button_DeletPaper.Click += new System.EventHandler(this.button_DeletPaper_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(426, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "像素";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "像素";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // checkBox_unit
            // 
            this.checkBox_unit.AutoSize = true;
            this.checkBox_unit.Location = new System.Drawing.Point(494, 315);
            this.checkBox_unit.Name = "checkBox_unit";
            this.checkBox_unit.Size = new System.Drawing.Size(119, 19);
            this.checkBox_unit.TabIndex = 19;
            this.checkBox_unit.Text = "以厘米为单位";
            this.checkBox_unit.UseVisualStyleBackColor = true;
            this.checkBox_unit.CheckedChanged += new System.EventHandler(this.checkBox_unit_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 508);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "CAD打印系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Print.ResumeLayout(false);
            this.tabPage_Print.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaperSizeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_printerlist;
        private System.Windows.Forms.Button button_runCAD;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox_userdef_printlen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_userdef_printwidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_PaperSizeList;
        private System.Windows.Forms.Button button_AddPaper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PaperName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_FindFile;
        private System.Windows.Forms.TextBox textBox_File2Print;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Print;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Time;
        private System.Windows.Forms.TextBox textBox_ImgNum;
        private System.Windows.Forms.DataGridView dgv_PaperSizeList;
        private System.Windows.Forms.Button button_DeletPaper;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_TargetAddr;
        private System.Windows.Forms.TextBox textBox_TargetAddr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_unit;
    }
}

