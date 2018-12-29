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

using System.IO.Ports;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 与被测表通信命令参数
    /// </summary>
    public sealed class MeterCommunicationCommandParameter : CommandParameter
    {
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
        /// 发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 数据格式是否为hex格式
        /// </summary>
        public bool IsHex { get; set; }

        /// <summary>
        /// 期望接收的数据
        /// </summary>
        public string ExpectedReceiveData { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public MeterCommunicationCommandParameter()
        { }

        /// <summary>
        /// 初始化与被测表通信初始化
        /// </summary>
        /// <param name="port">通信端口</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="parity">校验方式</param>
        public MeterCommunicationCommandParameter(CommunicationPort port, int baudRate, int dataBits, Parity parity)
        {
            ComPort = port;
            BaudRate = baudRate;
            DataBits = dataBits;
            Parity = parity;
        }

        /// <summary>
        /// 覆盖ToString()，输出属性值
        /// </summary>
        /// <returns>key=value形式字符串</returns>
        public override string ToString()
        {
            return string.Format("ComPort = {0}, BaudRate = {1}, DataBits = {2}, Parity = {3}", ComPort.ToString(), BaudRate, DataBits, Parity.ToString());
        }
    }
}
