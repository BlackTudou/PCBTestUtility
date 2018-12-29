/*
 * Copyright (C) 1994-2018 Microstar Electric Company Limited
 * 
 * All Rights Reserved.
 * 
 * LEGAL NOTICE: All information contained herein is, and 
 * remains the feild of Microstar Electric Company Limited. 
 * The intellectual and technical concepts contained herein 
 * are proprietary to Microstar Electric Company Limited, and 
 * may be covered by patents, patents in process and are 
 * protected by the trade secret or copyright laws. Commercial 
 * use, or disclosure, or dissemination, or reproduction of 
 * the information contained in this file are strictly 
 * forbidden unless official specific written permissions are 
 * obtained from Microstar Electric Company Limited.
 */

using Microstar.Production.PCBTest.Properties;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using Microstar.Production.Tools;

/* 记录：因为需要输入表号后按下回车，执行开始检测功能，所以我把那个textbox放在主界面中 */
namespace Microstar.Production.PCBTest
{
    /// <summary>
    /// 检测界面控件
    /// </summary>
    public partial class TestInterface : UserControl
    {
        /// <summary>
        /// 表号是否自动加1
        /// </summary>
        public bool MeterNumberAutoIncrement
        {
            get { return this.increasedByOneCheckBox.Checked; }
            set { this.increasedByOneCheckBox.Checked = value; }
        }

        /// <summary>
        /// 电压规格
        /// </summary>
        public decimal Voltage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.volTextBox.Text))
                {
                    this.volTextBox.Text = Settings.Default.Landing_Voltage.ToString();
                }

                return Convert.ToDecimal(this.volTextBox.Text);
            }
            set { this.volTextBox.Text = value.ToString(); }
        }

        /// <summary>
        /// 电流规格
        /// </summary>
        public string Current
        {
            get { return this.currentTextBox.Text; }
            set { this.currentTextBox.Text = value; }
        }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.baudRateTextBox.Text))
                {
                    this.baudRateTextBox.Text = Settings.Default.Landing_BaudRate.ToString();
                }

                return Convert.ToInt32(this.baudRateTextBox.Text);
            }
            set { this.baudRateTextBox.Text = value.ToString(); }
        }

        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode
        {
            get { return this.customerCodeTextBox.Text; }
            set { this.customerCodeTextBox.Text = value; }
        }

        /// <summary>
        /// DataGridView所显示的数据源
        /// </summary>
        public object DataSource
        {
            set { this.checkRecord2.DataSource = value; }
        }

        /// <summary>
        /// 最终检测结果显示
        /// </summary>
        public Image ResultImage
        {
            set { this.resultPictureBox.Image = value; }
        }

        /// <summary>
        /// 表号是否自动加一
        /// </summary>
        public bool EnableAtuoMetetNumberIncreased
        {
            get { return this.increasedByOneCheckBox.Checked; }
            set { this.increasedByOneCheckBox.Checked = value; }
        }

        /// <summary>
        /// 设置表号自动加一checkbox Enabled属性
        /// </summary>
        public bool EnableMetetNumberIncreasedCheckBox
        {
            set { this.increasedByOneCheckBox.Enabled = value; }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public TestInterface()
        {
            InitializeComponent();                 
        }

        /// <summary>
        /// 检测界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestInterface_Load(object sender, EventArgs e)
        {
            InitializeInterface();
        }

        /// <summary>
        /// 检测界面初始化显示
        /// </summary>
        private void InitializeInterface()
        {
            this.btnCheckRecord.Text = Resources.TestInterface_ExpandRecord;
            this.splitContainer1.Panel2Collapsed = true;
            this.increasedByOneCheckBox.Checked = true;
        }

        /// <summary>
        /// 检测记录收起与展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckRecord_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {
                this.btnCheckRecord.Text = Resources.TestInterface_CollapseRecord;
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                this.btnCheckRecord.Text = Resources.TestInterface_ExpandRecord;
                splitContainer1.Panel2Collapsed = true;
            }
        }

        /// <summary>
        /// 检测合格后表号自动加1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void increasedByOneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MeterNumberAutoIncrement = this.increasedByOneCheckBox.Checked;
        }
    }
}
