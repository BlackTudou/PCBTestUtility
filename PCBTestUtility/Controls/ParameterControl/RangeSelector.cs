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
using Microstar.Production.PCBTest.Command;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Microstar.Production.PCBTest.Controls
{
    /// <summary>
    /// 检测误差范围控件
    /// </summary>
    public partial class RangeSelector : UserControl, IParameterControl
    {
        /// <summary>
        /// 实现参数control接口
        /// </summary>
        public CommandParameter Parameter
        {
            get
            {
                var measureParameter = ProfileManager.Instance.GetCommandParameter(this.Header) as MeasureParameter;

                measureParameter.LowerLimit = this.LowerLimit;
                measureParameter.UpperLimit = this.UpperLimit;
                return measureParameter;
            }
            set
            {
                var measeureParameter = value as MeasureParameter;
                if (measeureParameter == null)
                {
                    return;
                }
                this.LowerLimit = measeureParameter.LowerLimit;
                this.UpperLimit = measeureParameter.UpperLimit;
            }
        }
        
        /// <summary>
        /// ID号，与选中的检测项目相匹配，且作为唯一标识
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 误差范围标题，标记是什么误差
        /// </summary>
        public string Header
        {
            get { return this.headerGroupBox.Text; }
            set { this.headerGroupBox.Text = value; }
        }

        /// <summary>
        /// 误差上限
        /// </summary>
        public decimal UpperLimit
        {
            get { return this.upperLimitNumericUpDown.Value; }
            set
            {
                if (value > Max || value < Min)
                {
                    return;
                }
                this.upperLimitNumericUpDown.Value = value;
            }
        }

        /// <summary>
        /// 误差下限
        /// </summary>
        public decimal LowerLimit
        {
            get { return this.lowerLimitNumericUpDown.Value; }
            set
            {
                if (value > Max || value < Min)
                {
                    return;
                }
                this.lowerLimitNumericUpDown.Value = value;
            }
        }

        /// <summary>
        /// 误差范围的最大值
        /// </summary>
        public decimal Max
        {
            get { return this.upperLimitNumericUpDown.Maximum; }
            set
            {
                this.upperLimitNumericUpDown.Maximum = value;
                this.lowerLimitNumericUpDown.Maximum = value;
            }
        }
 
        /// <summary>
        /// 误差范围的最小值
        /// </summary>
        public decimal Min
        {
            get { return this.lowerLimitNumericUpDown.Minimum; }
            set
            {
                this.upperLimitNumericUpDown.Minimum = value;
                this.lowerLimitNumericUpDown.Minimum = value;
            }
        }
     
        /// <summary>
        /// 初始化检测误差范围界面上的控件
        /// </summary>
        public RangeSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 限制输入的误差上限值最小值为误差下限值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upperLimitNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (LowerLimit > UpperLimit && LowerLimit != 0)
            {
                UpperLimit = LowerLimit;
            }
        }

        /// <summary>
        /// 限制输入的误差下限的最大值为误差上限值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lowerLimitNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (LowerLimit > UpperLimit && UpperLimit != 0)
            {
                LowerLimit = UpperLimit;
            }
        }
    }       
}
