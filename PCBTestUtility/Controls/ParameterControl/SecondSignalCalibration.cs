using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microstar.Production.PCBTest.Command;
using System.IO.Ports;

namespace Microstar.Production.PCBTest.Controls
{
    /// <summary>
    /// 秒信号误差控件
    /// </summary>
    public partial class SecondSignalCalibration : UserControl, IParameterControl
    {
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
        /// 实现IParameterControl接口
        /// </summary>
        public CommandParameter Parameter
        {
            get
            {
                var secondParameter = new SecondSignalCalibrationParameter();
                secondParameter.LowerLimit = this.LowerLimit;
                secondParameter.UpperLimit = this.UpperLimit;
                secondParameter.EnableActivateClockSignal = this.EnableActivateClockSignal;
                secondParameter.EnableAutoClockCompensation = this.EnableAutoClockCompensation;
                secondParameter.DelayTime = this.DelayTime;
                secondParameter.ClockSignalTestSeconds = this.ClockSignalTestSeconds;
                secondParameter.ComPort = this.ComPort;
                secondParameter.BaudRate = this.BaudRate;
                secondParameter.DataBits = this.DataBits;
                secondParameter.Parity = this.Parity;

                return secondParameter;
            }
            set
            {
                var secondParameter = value as SecondSignalCalibrationParameter;
                if (secondParameter == null)
                {
                    return;
                }

                this.LowerLimit = secondParameter.LowerLimit;
                this.UpperLimit = secondParameter.UpperLimit;
                this.EnableActivateClockSignal = secondParameter.EnableActivateClockSignal;
                this.EnableAutoClockCompensation = secondParameter.EnableAutoClockCompensation;
                this.DelayTime = secondParameter.DelayTime;
                this.ClockSignalTestSeconds = secondParameter.ClockSignalTestSeconds;
                this.ComPort = secondParameter.ComPort;
                this.BaudRate = secondParameter.BaudRate;
                this.DataBits = secondParameter.DataBits;
                this.Parity = secondParameter.Parity;
            }
        }
        
        /// <summary>
        /// 是否需要激活秒信（有些表需要激活秒信号）
        /// </summary>
        public bool EnableActivateClockSignal
        {
            get { return this.activateSecondCheckBox.Checked; }
            set { this.activateSecondCheckBox.Checked = value; }
        }

        /// <summary>
        /// 检测秒信号时是否自动对信号进行补偿
        /// </summary>
        public bool EnableAutoClockCompensation
        {
            get { return this.secondsCheckBox.Checked; }
            set { this.secondsCheckBox.Checked = value; }
        }

        /// <summary>
        /// 电表检测秒信号时测试的秒数（包括未进行补偿时）
        /// </summary>
        public int ClockSignalTestSeconds
        {
            get { return (int)this.secondsNumericUpDown.Value; }
            set { this.secondsNumericUpDown.Value = value; }
        }

        /// <summary>
        /// 开始检测与读秒信号之间的间隔时间
        /// </summary>
        public decimal DelayTime
        {
            get { return this.delayTimeNumericUpDown.Value; }
            set { this.delayTimeNumericUpDown.Value = value; }
        }

        /// <summary>
        /// 误差上限
        /// </summary>
        public decimal UpperLimit
        {
            get { return this.upperLimitNumericUpDown.Value; }
            set { this.upperLimitNumericUpDown.Value = value; }
        }

        /// <summary>
        /// 误差下限
        /// </summary>
        public decimal LowerLimit
        {
            get { return this.lowerLimitNumericUpDown.Value; }
            set { this.lowerLimitNumericUpDown.Value = value; }
        }

        /// <summary>
        /// 通信端口
        /// </summary>
        public CommunicationPort ComPort
        {
            get
            {
                if (this.comPortComboBox.SelectedIndex == -1)
                {
                    this.comPortComboBox.SelectedIndex = 0;
                }
                return (CommunicationPort)this.comPortComboBox.SelectedIndex;
            }
            set { this.comPortComboBox.SelectedIndex = value.GetHashCode(); }
        }

        /// <summary>
        /// 波特率可设置为：300,600,1200,2400,4800,9600,19200, 38400
        /// </summary>
        public int BaudRate
        {
            get
            {
                if (this.baudRateComboBox.SelectedIndex == -1)
                {
                    this.baudRateComboBox.SelectedIndex = 0;
                }
                return Convert.ToInt32(this.baudRateComboBox.SelectedItem.ToString());
            }
            set
            {
                this.baudRateComboBox.SelectedItem = value.ToString();
            }
        }

        /// <summary>
        /// 数据位可设置为：7,8
        /// </summary>
        public int DataBits
        {
            get
            {
                if (this.databitsComboBox.SelectedIndex == -1)
                {
                    this.databitsComboBox.SelectedIndex = 0;
                }
                return Convert.ToInt32(this.databitsComboBox.SelectedItem.ToString());
            }
            set
            {
                this.databitsComboBox.SelectedItem = value.ToString();
            }
        }

        /// <summary>
        /// 校验方式可设置为：N（无校验），O（奇校验），E（偶校验）
        /// </summary>
        public Parity Parity
        {
            get
            {
                if (this.parityComboBox.SelectedIndex == -1)
                {
                    this.parityComboBox.SelectedIndex = 0;
                }
                return (Parity)this.parityComboBox.SelectedIndex;
            }
            set { this.parityComboBox.SelectedIndex = value.GetHashCode(); }
        }

        public SecondSignalCalibration()
        {
            InitializeComponent();
        } 
    }
}
