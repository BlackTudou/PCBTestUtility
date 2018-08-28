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

    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.cmbUserName.Text;
            string userPassword = this.txtPassword.Text;

            if (userName.Equals("") || userPassword.Equals(""))
            {
                //MessageBox.Show("用户名或密码不能为空！");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            // 若不为空，验证用户名和密码是否与数据库匹配
            // 这里只做字符串对比验证
            else
            {
                //用户名和密码验证正确，提示成功，并执行跳转界面。
                if (userName.Equals("admin") && userPassword.Equals("admin"))
                {
                    //MessageBox.Show("登录成功！");

                    /**
                     * 待添加代码区域
                     * 实现界面跳转功能
                     * 
                     */
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    this.Close();
                }
                //用户名和密码验证错误，提示错误。
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }
            }
        }
    }
}
