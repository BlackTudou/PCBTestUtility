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
    /// 检测记录显示控件
    /// </summary>
    public partial class CheckRecord : UserControl
    {
        /// <summary>
        /// DataGridView所显示的数据源
        /// </summary>
        public object DataSource
        {
            set { this.dataGridView1.DataSource = value; }
        } 

        /// <summary>
        /// 构造函数，初始化控件
        /// </summary>
        public CheckRecord()
        {
            InitializeComponent();
        }
    }
}
