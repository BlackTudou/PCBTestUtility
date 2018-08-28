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
    public partial class MainForm1 : Form
    {
        //static Form form2 = null;
        static UsrManageDialog usrDialog = null;
        static DataBaseDialog dataDialog = null;
        static SerialSettingsDialog serialDialog = null;
        static OptionDialog opDialog = null;
        static ForceProgramDialog forceDialog = null;
        //static int count = 0;

        private object lockObject = new object();

        public MainForm1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
#if false
            lock(lockObject)
           
            if (form2 == null)
            {
                count++;
                MessageBox.Show(count.ToString());

                Form form2 = new MainForm2();
                this.Hide();
                form2.Show();
            }
#endif
            this.Hide();
            if (Application.OpenForms.Count == 1)
            {
                MainForm2 form2 = new MainForm2();
                form2.Show();
            }
            else
            {
                Application.OpenForms["MainForm2"].Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.cmbVol.SelectedIndex = 2;
            this.cmbCurrent.SelectedIndex = 0;
            this.cmbBaud.SelectedIndex = 4;
            this.cmbMeterNum.SelectedIndex = 0;
            this.cmbMeterType.SelectedIndex = 0;
            this.cmbProtocol.SelectedIndex = 0;

            this.treeView1.ExpandAll();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 用户管理XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usrDialog == null)
            {
                usrDialog = new UsrManageDialog();
            }
            if (usrDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void 数据库操作YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataDialog == null)
            {
                dataDialog = new DataBaseDialog();
            }

            if (dataDialog.ShowDialog() == DialogResult.OK)
            {

            }
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

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (opDialog == null)
            {
                opDialog = new OptionDialog();
            }
            if (opDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnForceProgram_Click(object sender, EventArgs e)
        {
            if (forceDialog == null)
            {
                forceDialog = new ForceProgramDialog();
            }
            if (forceDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
