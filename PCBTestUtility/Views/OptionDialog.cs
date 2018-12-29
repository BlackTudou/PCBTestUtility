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
using System;
using System.Windows.Forms;
using Microstar.Production.PCBTest.Properties;

namespace Microstar.Production.View
{
    /// <summary>
    /// 选项功能对话框
    /// </summary>
    public partial class OptionDialog : Form
    {
        /// <summary>
        /// 是否自动载入上次打开的测试文件
        /// </summary>
        public bool IsTestFileAuto
        {
            get { return this.fileCheckBox.Checked; }
            set { this.fileCheckBox.Checked = value; }
        }

        /// <summary>
        /// 初始化选项功能对话框上的控件
        /// </summary>
        public OptionDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载选项功能对话框界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionDialog_Load(object sender, EventArgs e)
        {                    
            this.bootCheckBox.Checked = Settings.Default.IsBootAuto;           
            this.fileCheckBox.Checked = Settings.Default.IsTestFileAuto;
            FileNameTextBoxInit();
        }

        /// <summary>
        /// 是否自动载入上次读取的测试文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FileNameTextBoxInit();
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            Settings.Default.IsBootAuto = this.bootCheckBox.Checked;
            Settings.Default.IsTestFileAuto = this.fileCheckBox.Checked;
            Settings.Default.FileName = this.fileNameTextBox.Text;
            Settings.Default.Save();
            
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FileNameTextBoxInit()
        {
            if (!this.fileCheckBox.Checked)
            {
                this.fileNameTextBox.Clear();
            }
            else
            {
                this.fileNameTextBox.Text = Settings.Default.FileName.ToString();
            }
        }
    }
}
