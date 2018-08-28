using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //显示登录窗口
            LoginDialog logDlg = new LoginDialog();
            logDlg.ShowDialog();

            if (logDlg.DialogResult == DialogResult.OK)
            {
                logDlg.Dispose();
                Application.Run(new MainForm1());
            }
            else
            {
                logDlg.Dispose();
                return;
            }
        }
    }
}
