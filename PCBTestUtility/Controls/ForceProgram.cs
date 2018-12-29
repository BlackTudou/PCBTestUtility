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

namespace Microstar.Production.PCBTest
{
    /// <summary>
    /// 强制编程相关信息显示（强编芯片号，电表类型，客户代码，校验和）
    /// </summary>
    public partial class ForceProgram : UserControl
    {
        /// <summary>
        /// 强制编程芯片口号
        /// </summary>
        public int ProgramChip 
        {
            get
            {
                if (this.programChipComboBox.SelectedIndex == -1)
                {
                    this.programChipComboBox.SelectedIndex = 0;
                }
                return this.programChipComboBox.SelectedIndex + 1;
            }
            set
            {
                if (value < 1 || value > 5)
                {
                    value = 1;
                }
                this.programChipComboBox.SelectedIndex = value - 1;
            }              
        }

        /// <summary>
        /// 电表类型
        /// </summary>
        public ConnectionType MeterType
        {
            get
            {
                if (this.meterTypeComboBox.SelectedIndex == -1)
                {
                    this.meterTypeComboBox.SelectedIndex = 0;
                }
                return (ConnectionType)this.meterTypeComboBox.SelectedIndex;
            }
            set { this.meterTypeComboBox.SelectedIndex = value.GetHashCode(); }
        }
        
        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode
        {
            get { return this.customerCodeComboBox.SelectedText; }
            set { this.customerCodeComboBox.SelectedText = value; }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public string CheckSum
        {
            get { return this.checkSumTextBox.Text; }
            set { this.checkSumTextBox.Text = value; }
        }

        /// <summary>
        /// 构造函数，初始化控件
        /// </summary>
        public ForceProgram()
        {
            InitializeComponent();
        }     
    }
}
