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
using System.Collections.Generic;
using System.Windows.Forms;

namespace Microstar.Production.PCBTest.Controls
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public partial class Pager : UserControl
    {
        private int recordCount = 0;
        private int pageIndex = 1;
        private int pageSize = 100;
        private int pageCount = 0;
        private bool isTextChanged = false;

        public event EventHandler OnPageChanged;

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
       
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }


        /// <summary>
        /// pageSize ComboBox控件里的pageSize集合
        /// </summary>
        public int[] PageSizes
        {
            get
            {
                List<int> pageSize = new List<int>();
                foreach (var item in this.pageSizeComboBox.Items)
                {
                    pageSize.Add(Convert.ToInt32(item.ToString()));
                }
                return pageSize.ToArray();
            }

            set
            {
                this.pageSizeComboBox.Items.Clear();
                foreach (var item in value)
                {
                    this.pageSizeComboBox.Items.Add(item.ToString());
                }
            }
        }
      
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }
       
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (pageSize != 0)
                {
                    pageCount = GetPageCount();
                }
                return pageCount;
            }
        }

        
        public Pager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设窗体控件全部可用
        /// </summary>
        private void SetFormCtrEnabled()
        {
            firstButton.Enabled = true;
            previousButton.Enabled = true;
            nextButton.Enabled = true;
            lastButton.Enabled = true;
            goButton.Enabled = true;
        }

        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <returns></returns>
        private int GetPageCount()
        {
            if (PageSize == 0)
            {
                return 0;
            }
            int pageCount = RecordCount / PageSize;
            if (RecordCount % PageSize == 0)
            {
                pageCount = RecordCount / PageSize;
            }
            else
            {
                pageCount = RecordCount / PageSize + 1;
            }
            return pageCount;
        }

        /// <summary>
        /// 用于客户端调用
        /// </summary>
        public void DrawControl(int count)
        {
            recordCount = count;
            DrawControl(false);
        }

        /// <summary>
        /// 根据不同的条件，改变页面控件的呈现状态
        /// </summary>
        private void DrawControl(bool callEvent)
        {
            currentPageLabel.Text = PageIndex.ToString();
            pageCountLabel.Text = PageCount.ToString();
            totalCountLabel.Text = RecordCount.ToString();
            pageSizeComboBox.SelectedItem = PageSize.ToString();

            if (callEvent && OnPageChanged != null)
            {
                OnPageChanged(this, null);//当前分页数字改变时，触发委托事件
            }
            SetFormCtrEnabled();
            if (PageCount == 1)//有且仅有一页时
            {
                firstButton.Enabled = false;
                previousButton.Enabled = false;
                nextButton.Enabled = false;
                lastButton.Enabled = false;
                goButton.Enabled = false;
            }
            else if (PageIndex == 1)//当前页为第一页时
            {
                firstButton.Enabled = false;
                previousButton.Enabled = false;
            }
            else if (PageIndex == PageCount)//当前页为最后一页时
            {
                nextButton.Enabled = false;
                lastButton.Enabled = false;
            }
        }

        //首页按钮
        private void firstButton_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            DrawControl(true);
        }

        //上一页按钮
        private void previousButton_Click(object sender, EventArgs e)
        {
            PageIndex = Math.Max(1, PageIndex - 1);
            DrawControl(true);
        }

        //下一页按钮
        private void nextButton_Click(object sender, EventArgs e)
        {
            PageIndex = Math.Min(PageCount, PageIndex + 1);
            DrawControl(true);
        }

        //尾页按钮
        private void lastButton_Click(object sender, EventArgs e)
        {
            PageIndex = PageCount;
            DrawControl(true);
        }

        /// <summary>
        /// 按下enter键，执行跳转页面功能
        /// </summary>
        private void pageNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar == Keys.Enter)
            goButton_Click(null, null);
        }

        /// <summary>
        /// 跳转页数限制
        /// </summary>
        private void pageNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (int.TryParse(pageNumberTextBox.Text.Trim(), out num) && num > 0)
            {   //TryParse 函数，将字符串转换成等效的整数，返回bool型，判断是否转换成功。
                //输入除数字以外的字符是转换不成功的

                if (num > PageCount)   //输入数量大于最大页数时，文本框自动显示最大页数
                {
                    pageNumberTextBox.Text = PageCount.ToString();
                }
            }
        }

        /// <summary>
        /// 跳转按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goButton_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (int.TryParse(pageNumberTextBox.Text.Trim(), out num) && num > 0)
            {
                PageIndex = num;
                DrawControl(true);
            }
        }

        /// <summary>
        /// 光标离开 每页设置文本框时，显示到首页
        private void pageSizeTextBox_Leave(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                isTextChanged = false;
                firstButton_Click(null, null);
            }
        }

        /// <summary>
        /// 每页显示的记录数改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string num = this.pageSizeComboBox.SelectedItem.ToString();
            isTextChanged = true;

            pageSize = Convert.ToInt32(num);
        }
    }
}
