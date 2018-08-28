using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest
{
    public partial class MainForm2 : Form
    {
        static UsrManageDialog usrDialog = null;
        static DataBaseDialog dataDialog = null;
        static SerialSettingsDialog serialDialog = null;
        static OptionDialog opDialog = null;

        public MainForm2()
        {
            InitializeComponent();
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {
    
        }


        /// <summary>
        /// 关闭子窗口，同时关闭父窗口进程
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Exit(e);
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms["MainForm1"].Show();
            //MessageBox.Show(Application.OpenForms.Count.ToString());
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            this.txtNumber.Enabled = false;
            this.checkBox1.Enabled = false;
            this.btnForward.Enabled = false;

            this.lblTime.Visible = true;
            //this.Close();
        }

        private void 串口设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialDialog == null)
            {
                serialDialog = new SerialSettingsDialog();
            }
            if (serialDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void 选项ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (opDialog == null)
            {
                opDialog = new OptionDialog();
            }
            if (opDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void 用户管理XToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (usrDialog == null)
            {
                usrDialog = new UsrManageDialog();
            }
            if (usrDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void 数据库操作YToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataDialog == null)
            {
                dataDialog = new DataBaseDialog();
            }

            if (dataDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
