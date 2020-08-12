using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace printFormsApp1
{
    public partial class MessageForm : Form
    {
        public MessageForm(int Max)
        {
            InitializeComponent();
            progressBar1.Maximum = Max;
            progressBar1.Value = 0;
        }

        public void setPos(int val)
        {
            if (val < progressBar1.Maximum)
            {
                progressBar1.Value = val;
                label2.Text = (val * 100 / progressBar1.Maximum).ToString() + "%";
            }
            Application.DoEvents();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }
    }
}
