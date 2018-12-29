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
using System.IO.Ports;
using System.Xml.Serialization;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 秒信号检测参数
    /// </summary>
    [Serializable]
    public sealed class SecondSignalCalibrationParameter : RangeCommandParameter
    {
        /// <summary>
        /// 是否需要激活秒信（有些表需要激活秒信号）
        /// </summary>
        public bool EnableActivateClockSignal { get; set; }

        /// <summary>
        /// 检测秒信号时是否自动对信号进行补偿
        /// </summary>
        public bool EnableAutoClockCompensation { get; set; }

        /// <summary>
        /// 开始检测与读秒信号之间的间隔时间
        /// </summary>
        public decimal DelayTime { get; set; }

        /// <summary>
        /// 电表检测秒信号时测试的秒数（包括未进行补偿时）
        /// </summary>
        public int ClockSignalTestSeconds { get; set; }

        /// <summary>
        /// 通信端口
        /// </summary>
        public CommunicationPort ComPort { get; set; }

        /// <summary>
        /// 波特率可设置为：300,600,1200,2400,4800,9600,19200, 38400
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 数据位可设置为：7,8
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// 校验方式可设置为：N（无校验），O（奇校验），E（偶校验）
        /// </summary>
        public Parity Parity { get; set; }

        /// <summary>
        /// 期望的范围值
        /// </summary>
        [XmlIgnore]
        public string ExpectedValueRange
        {
            get { return string.Format("{0}-{1}", this.LowerLimit, this.UpperLimit); }
        }

        /// <summary>
        /// 覆盖ToString()，输出属性值
        /// </summary>
        /// <returns>key=value形式字符串</returns>
        public override string ToString()
        {
            return string.Format(
                "EnableActivateClockSignal = {0}, " +
                "EnableAutoClockCompensation = {1}, " +
                "DelayTime = {2}, " +
                "ClockSignalTestSeconds = {3}", 
                EnableActivateClockSignal, 
                EnableAutoClockCompensation, 
                DelayTime, 
                ClockSignalTestSeconds);
        }
    }
}
