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

using Microstar.Production.Tools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microstar.Production.PCBTest.Business;

namespace Microstar.Production.View
{
    /// <summary>
    /// 数据库查看对话框
    /// </summary>
    public partial class DataViewer : Form
    {
        /// <summary>
        /// 初始化数据库查看对话框上的控件
        /// </summary>
        public DataViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataViewer_Load(object sender, EventArgs e)
        {
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            LoadData();
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = TestRecordManager.Instance.GetTestRecords(new Pagination(this.pagerControl1.PageIndex, this.pagerControl1.PageSize));
            this.dataGridView1.DataSource = list;
            pagerControl1.DrawControl(TestRecordManager.Instance.GetTestRecordCount());
        }
    }
}
