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
using Microstar.Production.PCBTest.Properties;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Microstar.Production.View
{
    /// <summary>
    /// 串口设置对话框
    /// </summary>
    public partial class SerialSettingsDialog : Form
    {
        /// <summary>
        ///  初始化串口设置对话框上的控件
        /// </summary>
        public SerialSettingsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 记录串口设置对话框加载次数
        /// </summary>
        private int loadCount = 0;

        /// <summary>
        /// 串口设置对话框的初始化，从C#设置系统中获取上次保存的串口设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialSettingsDialog_Load(object sender, EventArgs e)
        {
            //获取当前计算机串口端口名，加载到对应combobox中
            string[] ports = SerialPort.GetPortNames();
            loadCount++;

            if (ports.Length > 0)
            {               
                if (loadCount == 1)
                {
                    Array.Sort(ports);
                    this.portNameComboBox.Items.AddRange(ports);
                }
                this.portNameComboBox.SelectedItem = Settings.Default.PortName.ToString(); //从C#设置系统中读取串口端口号的设置                             
            }
            else
            {
               this. portNameComboBox.Text = Resources.SerialSettingsDialog_NoUsedPort;
            }


            //从C#设置系统中中加载串口波特率、数据位、校验位、停止位的设置
            this.baudRateComboBox.SelectedItem = Settings.Default.BaudRate.ToString();
            this.dataBitsComboBox.SelectedItem = Settings.Default.DataBits.ToString();
            this.parityComboBox.SelectedItem = Settings.Default.Parity;
            this.stopBitsComboBox.SelectedItem = Settings.Default.StopBit.ToString();
        }

        /// <summary>
        /// 保存串口设置到C#设置系统中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {                    
            Settings.Default.PortName = this.portNameComboBox.SelectedItem.ToString();
            Settings.Default.BaudRate = Convert.ToInt32(this.baudRateComboBox.SelectedItem as string);
            Settings.Default.DataBits = Convert.ToInt32(this.dataBitsComboBox.SelectedItem as string);
            Settings.Default.Parity = this.parityComboBox.SelectedItem as string;
            Settings.Default.StopBit = Convert.ToInt32(this.stopBitsComboBox.SelectedItem as string);
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
    }
}
