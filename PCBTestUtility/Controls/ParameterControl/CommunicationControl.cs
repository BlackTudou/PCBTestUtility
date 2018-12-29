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
using System.Windows.Forms;

namespace Microstar.Production.PCBTest.Controls
{
    /// <summary>
    /// 透明通道传输误差控件
    /// </summary>
    public partial class CommunicationControl : UserControl, IParameterControl
    {
        /// <summary>
        /// 实现IParameterControl接口
        /// </summary>
        public CommandParameter Parameter
        {
            get
            {
                var communicationParameter = ProfileManager.Instance.GetCommandParameter(this.Header) as MeterCommunicationCommandParameter;
                communicationParameter.SendData = this.SendData;
                communicationParameter.ExpectedReceiveData = this.ReceiveData;
                communicationParameter.IsHex = this.IsHex;

                return communicationParameter;
            }
            set
            {
                var communicationParameter = value as MeterCommunicationCommandParameter;
                if (communicationParameter == null)
                {
                    return;
                }
                this.SendData = communicationParameter.SendData;
                this.ReceiveData = communicationParameter.ExpectedReceiveData;
                this.IsHex = communicationParameter.IsHex;
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
        /// 发送的数据
        /// </summary>
        public string SendData
        {
            get { return this.sendTextBox.Text; }
            set { this.sendTextBox.Text = value; }
        }

        /// <summary>
        /// 接收的数据
        /// </summary>
        public string ReceiveData
        {
            get { return this.receiveTextBox.Text; }
            set { this.receiveTextBox.Text = value; }
        }

        /// <summary>
        /// 是否以hex发送
        /// </summary>
        public bool IsHex
        {
            get { return this.hexRadioButton.Checked; }
            set
            {
                this.hexRadioButton.Checked = value;
                this.textRadioButton.Checked = !value;
            }
        }

        public CommunicationControl()
        {
            InitializeComponent();
        }

        private void CommunicationControl_Load(object sender, System.EventArgs e)
        {
            this.textRadioButton.Enabled = false;
        }
    }
}
