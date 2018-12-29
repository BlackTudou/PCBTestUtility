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
using System.Windows.Forms;
using System;

namespace Microstar.Production.PCBTest
{
    /// <summary>
    /// 检测项目控件
    /// </summary>
    public partial class TestItem : UserControl
    {
        /// <summary>
        /// 检测项目名字
        /// </summary>
        public string TestName
        {
            get { return this.testNameLabel.Text; }
            set { this.testNameLabel.Text = value; }
        }

        /// <summary>
        /// 标识检测项目控件
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 该检测项目结果
        /// </summary>
#if false
        public TestResult TestResult
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.testResultTextBox.Text))
                {
                    return TestResult.NotRun;
                }
                return (TestResult)Enum.Parse(typeof(TestResult),this.testResultTextBox.Text);
            }
            set { this.testResultTextBox.Text = value.ToString(); }
        }
#endif
        public string TestResult
        {
            get { return this.testResultTextBox.Text; }
  
            set { this.testResultTextBox.Text = value; }
        }

        /// <summary>
        /// 检测项进行的状态，是否正在执行
        /// </summary>
        public bool IsTesting
        {
            get { return this.landingPictureBox.Visible; }
            set { this.landingPictureBox.Visible = value; }
        }

        /// <summary>
        /// 构造函数，初始化控件
        /// </summary>
        public TestItem()
        {
            InitializeComponent();
        }
    }
}
