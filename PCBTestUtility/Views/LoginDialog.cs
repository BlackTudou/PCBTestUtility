/*
 * Copyright (C) 1994-2018 Microstar Electric Company Limited
 * 
 * All Rights Reserved.
 * 
 * LEGAL NOTICE: All information contained herein is, and 
 * remains the property of Microstar Electric Company Limited. 
 * The intellectual and technical concepts contained herein 
 * are proprietary to Microstar Electric Company Limited, and 
 * may be covered by patents, patents in process and are 
 * protected by the trade secret or copyright laws. Commercial 
 * use, or disclosure, or dissemination, or reproduction of 
 * the information contained in this file are strictly 
 * forbidden unless official specific written permissions are 
 * obtained from Microstar Electric Company Limited.
 */
using Microstar.Production.PCBTest.Business;
using Microstar.Production.PCBTest.Properties;
using Microstar.Production.Tools;
using System;
using System.Windows.Forms;

namespace Microstar.Production.View
{
    /// <summary>
    /// 登录对话框
    /// </summary>
    public partial class LoginDialog : Form
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return this.userNameComboBox.Text.Trim(); }
            set { this.userNameComboBox.Text = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return this.passwordTextBox.Text; }
            set { this.passwordTextBox.Text = value; }
        }

        /// <summary>
        /// 初始化登录对话框上的控件
        /// </summary>
        public LoginDialog()
        {
            InitializeComponent();          
        }

        /// <summary>
        /// 加载登录对话框界面显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginDialog_Load(object sender, EventArgs e)
        {
            this.passwordTextBox.Text = "123456";
            UserName = Settings.Default.Login_UserName;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (UserName.Equals(""))
            {
                MessageBoxHelper.ShowError(Resources.LoginDialog_UserNameEmpty);
                return;
            }
            if (Password.Equals(""))
            {
                MessageBoxHelper.ShowError(Resources.LoginDialog_PasswordEmpty);
                return;
            }

            var user = UserManager.Instance.Login(UserName, Password);
            if (user == null)
            {
                MessageBoxHelper.ShowError(Resources.LoginDialog_LoginFailed);
                return;
            }

            //登录成功
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 关闭登录对话框时保存本次的登录用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Login_UserName = UserName;
            Settings.Default.Save();
        }
    }
}
