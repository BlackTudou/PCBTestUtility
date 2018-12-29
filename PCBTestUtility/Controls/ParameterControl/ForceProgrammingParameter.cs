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

using Microstar.Production.PCBTest.Command;
using System;
using System.Windows.Forms;

namespace Microstar.Production.PCBTest.Controls
{
    /// <summary>
    /// 检测强制编程参数控件
    /// </summary>
    public partial class ForceProgrammingParameter : UserControl, IParameterControl
    {
        /// <summary>
        /// 实现参数control接口
        /// </summary>
        public CommandParameter Parameter
        {
            get
            {               
                return new ForceProgramCommandParameter(this.I2CChipSelect, this.I2CAddress, this.SpiAddress, this.Length);
            }
            set
            {
                var programParameter = value as ForceProgramCommandParameter;
                if (programParameter == null)
                {
                    return;
                }
                this.I2CChipSelect = programParameter.I2CChipSelect;
                this.I2CAddress = programParameter.I2CAddress;
                this.SpiAddress = programParameter.SpiAddress;
                this.Length = programParameter.Length;
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
        /// I2C片选码，当片选码为0xFF时，读取RN8215内部EEPROM。
        /// </summary>
        public byte I2CChipSelect
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.i2cChipSelectComboBox.SelectedItem.ToString()))
                {
                    this.i2cChipSelectComboBox.SelectedIndex = 0;
                }
                return Convert.ToByte(this.i2cChipSelectComboBox.SelectedItem.ToString(), 16);
            }
            set
            {
                if (value == 0)
                {
                    this.i2cChipSelectComboBox.SelectedIndex = 0;
                }
                this.i2cChipSelectComboBox.SelectedItem = string.Format("{0:X2}", value);
            }
        }

        /// <summary>
        /// I2C地址，I2C地址取值范围是0x0000-0xFFFF。
        /// </summary>
        public uint I2CAddress
        {
            get
            {
                return Convert.ToUInt32(this.i2cAddressComboBox.Text, 16);
            }
            set
            {
                this.i2cAddressComboBox.Text = string.Format("{0:X}", value);
            }
        }

        /// <summary>
        /// SPI地址
        /// </summary>
        public uint SpiAddress
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.spiAddressComboBox.SelectedItem.ToString()))
                {
                    this.spiAddressComboBox.SelectedIndex = 0;
                }
                return Convert.ToUInt32(this.spiAddressComboBox.SelectedItem.ToString());
            }
            set
            {
                if (value == 0)
                {
                    this.spiAddressComboBox.SelectedIndex = 0;
                }
                this.spiAddressComboBox.SelectedItem = value.ToString();
            }
        }

        /// <summary>
        /// 读取长度
        /// </summary>
        public uint Length
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.lengthComboBox.SelectedItem.ToString()))
                {
                    this.lengthComboBox.SelectedIndex = 0;
                }
                return Convert.ToUInt32(this.lengthComboBox.SelectedItem.ToString());
            }
            set
            {
                if (value == 0)
                {
                    this.lengthComboBox.SelectedIndex = 0;
                }
                this.lengthComboBox.SelectedItem = value.ToString();
            }
        }

        /// <summary>
        /// 构造函数，初始化控件
        /// </summary>
        public ForceProgrammingParameter()
        {
            InitializeComponent();
        }
    }
}
