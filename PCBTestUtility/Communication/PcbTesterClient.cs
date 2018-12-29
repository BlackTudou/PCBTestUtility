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
using System.Collections.Generic;
using System.IO.Ports;
using System.Resources;
using System.Text;
using Microstar.Production.Tools;
using System.Globalization;
using System.Threading;

namespace Microstar.Production.Comms.PCB
{
    /// <summary>
    /// 串口工具类，用于与检测板通信，发送检测命令以及读取检测结果
    /// </summary>
    public sealed class PcbTesterClient : IDisposable
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PcbTesterClient));
        private SerialPort serialPort = null;
        private bool disposed = false;

        public static readonly int timeoutValue = 100000;
        public static readonly int retransmissionCount = 3;

        /// <summary>
        /// 获取或设置通信端口。
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// 获取或设置串行波特率。
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 记录PCBTesterClient是否当前状态为Open
        /// </summary>
        public bool IsOpen { get; set; } = false;

        /// <summary>
        /// 创建PcbTesterClient类的实例
        /// </summary>
        /// <param name="portName">端口号</param>
        /// <param name="baudRate">波特率</param>
        /// <returns>PcbTesterClient实例</returns>
        public static PcbTesterClient Create(string portName, int baudRate)
        {
            if (portName == null)
            {
                throw new ArgumentNullException("portName");
            }

            if (baudRate == 0)
            {
                throw new ArgumentNullException("baudRate");
            }

            if (baudRate % 300 != 0 || baudRate < 0)
            {
                throw new ArgumentException();
            }

            return new PcbTesterClient(portName, baudRate);
        }

        /// <summary>
        ///  防止直接调用构造函数
        /// </summary>
        /// <param name="portName">端口号</param>
        /// <param name="baudRate">波特率</param>
        private PcbTesterClient(string portName, int baudRate)
        {
            this.PortName = portName;
            this.BaudRate = baudRate;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        ~PcbTesterClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public void Open()
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort(this.PortName, this.BaudRate, Parity.Even, 7, StopBits.One);
                serialPort.ReadTimeout = Settings.Default.SerialReadTimeout;
                serialPort.ReadBufferSize = 4096;
            }

            //如果串口是打开的，先关闭
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

            try
            {
                serialPort.Open();
                this.IsOpen = true;
            }
            catch (Exception ex)
            {
                throw new CommunicationException(ex.Message);
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            if (serialPort == null)
            {
                this.IsOpen = false;
                return;
            }

            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                    this.IsOpen = false;
                }
                catch (Exception ex)
                {
                    throw new CommunicationException(ex.Message);
                }
            }
        }

        /// <summary>
        ///  给检测板写开始检测命令，并解析检测板回复的应答数据帧
        /// </summary>
        /// <param name="obis">OBIS码</param>
        /// <param name="parameter">obis参数,若obis参数为空，传入""或string.Empty</param>
        public WriteResult Write(string obis, string parameter)
        {
            byte[] startTestCommand = GetCommand(obis, true, parameter);
            byte[] recvData;

            bool wrongFrameFlag = true;
            string str = string.Empty;
            while(wrongFrameFlag)
            {
                try
                {
                    //将检测命令发给检测板,并等待检测板回复应答结果         
                    recvData = WriteCommand(startTestCommand, timeoutValue);
                }
                catch (CommunicationException ex)
                {
                    throw new CommunicationException(ex.Message);
                }

                //以下是对检测板回复应答帧的解析 正确应答：Success，异常应答：STX (ERR_Code) ETX BCC
                int index = Array.IndexOf(recvData, (byte)0x06);

                //正确应答 ACK
                if (index != -1)
                {
                    return new WriteResult(true);
                }
                
                try
                {
                    str = ParseReply(recvData);
                }
                catch (CommunicationException)  //错误帧
                {
                    wrongFrameFlag = true;
                    continue;
                }

                //错误帧，e.g. 02 28 30 29 03 32，虽然是完整帧，但既不是ACK 也不是异常应答(STX (ERR_Code) ETX BCC)
                if (!(str.Contains("ERR") && str.Length == 6)) //错误帧
                {
                    wrongFrameFlag = true;
                    continue;
                    //throw new CommunicationException(Resources.IncorrectResponse);
                }
            }
            //异常应答完整数据帧
            WriteError error = new WriteError();
            error.ErrorCode = ParseExceptionResponse(str);
   
            return new WriteResult(false, error);
        }

        /// <summary>
        /// 往串口发送数据
        /// </summary>
        /// <param name="writeData">发送的数据</param>
        /// <param name="isHex">是否以HEX码发送</param>
        /// <returns>串口回复的数据</returns>
        public byte[] Write(string writeData, bool isHex)
        {
            if (!isHex) //Text形式
            {
                byte[] sendBuffer = Encoding.ASCII.GetBytes(writeData);
                return WriteCommand(sendBuffer, timeoutValue); 
            }
            else
            {
                byte[] sendBuffer = Microstar.Utility.Hex.FromString(writeData);
                return WriteCommand(sendBuffer, timeoutValue);
            }
        }
#if true
        public void Write(string obis, byte[] binData,uint address)
        {
            List<byte> sendBuffer = new List<byte>();
            sendBuffer.AddRange(new byte[] { 0x01, 0x57, 0x31, 0x02 });
            sendBuffer.AddRange(Encoding.ASCII.GetBytes(obis));

            sendBuffer.AddRange(new byte[] { 0x28, 0x30, 0x78 }); //左括号

            sendBuffer.AddRange(Encoding.ASCII.GetBytes(address.ToString("X")));
            sendBuffer.Add(0x2C);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in binData)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            //sendBuffer.AddRange(binData);
            sendBuffer.AddRange(Encoding.ASCII.GetBytes(sb.ToString()));

            sendBuffer.Add(0x29); //右括号
            sendBuffer.Add(0x03); //ETX

            //计算数据帧的BCC值
            byte bcc = IecBcc.Calculate(sendBuffer.ToArray(), 1, sendBuffer.Count - 1);
            sendBuffer.Add(bcc); //BCC

            WriteCommand(sendBuffer.ToArray(), timeoutValue);
        }
#endif

        /// <summary>
        /// 读取检测结果
        /// </summary>
        /// <param name="obis">OBIS码</param>
        /// <param name="parameter">OBIS参数</param>
        /// <returns>检测板返回结果</returns>
        public ReadResult Read(string obis, string parameter)
        {
            //组帧
            byte[] readResultCommand = GetCommand(obis, false, parameter);
            string testResult = string.Empty;

            int i = 0;
            for (i = 0; i < retransmissionCount; i++) 
            {
                //发帧
                byte[] recvData = WriteCommand(readResultCommand, timeoutValue);

                try
                {
                    //解析帧，将括号里的内容读出来
                    testResult = ParseReply(recvData);
                }
                catch (CommunicationException) //错误帧，重传
                {
                    continue;
                }
                break;
            }
            if (i == retransmissionCount)
            {
                throw new CommunicationException(Resources.IncorrectResponse);
            }

            if (testResult.Contains("ERR") && testResult.Length == 6)
            {
                WriteError error = new WriteError();
                error.ErrorCode = ParseExceptionResponse(testResult);

                return new ReadResult(false, error);
            }
            return new ReadResult(true, testResult);
        }

        /// <summary>
        /// 读取检测结果
        /// </summary>
        /// <param name="obis">OBIS码</param>
        /// <param name="parameter">OBIS参数</param>
        /// <param name="testResult">括号里面的检测结果或者错误码</param>
        /// <returns>是否检测成功</returns>
        public bool TryRead(string obis, string parameter, out ReadResult testResult)
        {
            //组帧
            byte[] readResultCommand = GetCommand(obis, false, parameter);

            //发帧
            byte[] recvData = WriteCommand(readResultCommand, timeoutValue);

            //解析帧，将括号里的内容读出来
            string readResult = ParseReply(recvData);

            if (readResult.Contains("ERR") && readResult.Length == 6)
            {
                WriteError error = new WriteError();
                error.ErrorCode = ParseExceptionResponse(readResult);
                testResult = new ReadResult(false, error);
                
                return false;
            }
            testResult = new ReadResult(true, readResult);
            return true;
        }

        /// <summary>
        /// 解析完整应答信息
        /// </summary>
        /// <param name="recvData">应答数据帧</param>
        /// <returns>返回应答信息括号里面的内容</returns>
        public string ParseReply(byte[] recvData)
        {           
            int head = Array.IndexOf(recvData, (byte)0x02);
            int tail = Array.IndexOf(recvData, (byte)0x03);
           
            if (head == -1 || tail == -1 || tail - head < 3) //未找到帧头、帧尾，数据帧不完整。完整帧：STX (data) ETX BCC，至少6位 
            {
                throw new CommunicationException(Resources.IncompleteData);
            }
          
            //计算数据帧BCC值       
            byte bcc = IecBcc.Calculate(recvData, head + 1, tail);

            if (tail == recvData.Length - 1) //无校验位
            {
                throw new CommunicationException(Resources.IncorrectResponse);
            }
          
            //检验失败,BCC错误
            if (bcc != recvData[tail + 1])
            {
                throw new CommunicationException(Resources.IncorrectResponse);
            }     

            //以下处理的是正确帧

            //找左括号
            int leftBracketIndex = Array.IndexOf(recvData, (byte)0x28);
            //找右括号
            int rightBracketIndex = Array.IndexOf(recvData, (byte)0x29);

            byte[] resultArray = new byte[rightBracketIndex - leftBracketIndex - 1];

            //将括号里的内容拷贝到结果数组resultArray中
            Array.ConstrainedCopy(recvData, leftBracketIndex + 1, resultArray, 0, rightBracketIndex - leftBracketIndex - 1);

            return Encoding.ASCII.GetString(resultArray);
        }

        /// <summary>
        /// 实现IDisposable接口。释放由 PcbTesterClient 使用的所有资源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放由 PcbTesterClient 占用的串口资源。
        /// </summary>
        /// <param name="disposing">若要释放托管资源和非托管资源，则为 true；若仅释放非托管资源，则为 false。</param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    this.Close();
                    serialPort.Dispose();
                }

                //Clean up unmanaged resources here.

                //Note disposing has been done.
                disposed = true;
            }
        }

        /// <summary>
        /// 使用串口发送检测命令,等待检测板返回数据
        /// </summary>
        /// <param name="command">命令字节</param>
        /// <param name="timeOutValue">超时时间，以ms为单位</param>
        /// <returns>检测板返回的数据</returns>
        private byte[] WriteCommand(byte[] command, int timeOutValue)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);

            if (serialPort == null || !serialPort.IsOpen)
            {
                throw new CommunicationException(Resources.SerialPortNoOpen);
            }

            for (int i = 0; i < retransmissionCount; i++)  //检测板未回复消息 则重传retransmissionCount次
            {
                try
                {
                    serialPort.Write(command, 0, command.Length);//发送数据
                }
                catch (Exception ex)
                {
                    throw new CommunicationException(ex.Message);
                }

                //阻塞，直到检测板返回数据
                bool waitResult = WaitForByte(timeOutValue);
                
                if (waitResult)
                {
                    break;
                }

                if (!waitResult && i < retransmissionCount - 1)
                {
                    continue;
                }
                else
                {
                    throw new CommunicationException(Resources.PcbTesterClient_NoBoard);               
                }
            }
                     
            //开一个足够大的buffer，用于读串口数据
            byte[] buffer = new byte[4096];
            int length = 0;          
            while (true)
            {           
                try
                {
                    length += serialPort.Read(buffer, length, buffer.Length - length);//将每次读到的字节数做累加，得到总共读到的字节数               
                    if (IsIecComplete(buffer, length))
                    {
                        byte[] result = new byte[length];

                        Array.Copy(buffer, 0, result, 0, result.Length);
                        logger.DebugFormat("Received bytes:{0}", Microstar.Utility.Hex.ToString(result, 0, result.Length));
                        return result;
                    }
                }

                catch (TimeoutException ex)
                {
                    byte[] result = new byte[length];

                    Array.Copy(buffer, 0, result, 0, result.Length);
                    logger.ErrorFormat("TimeoutException, Received bytes:{0}", Microstar.Utility.Hex.ToString(result, 0, result.Length));
                    throw new CommunicationException(ex.Message);
                }
            }
        }

        /// <summary>
        /// 组帧
        /// </summary>
        /// <param name="obis">obis码</param>
        /// <param name="isWrite">true:WriteCommand, false:ReadCommand</param>
        /// <param name="parameter">obis参数</param>
        /// <returns>待发送的数据帧</returns>
        private byte[] GetCommand(string obis, bool isWrite, string parameter)
        {
            List<byte> command = new List<byte>();

            if (isWrite)
            {
                command.AddRange(new byte[] { 0x01, 0x57, 0x31, 0x02 }); //SOH W1 STX
            }
            else
            {
                command.AddRange(new byte[] { 0x01, 0x52, 0x31, 0x02 }); //SOH R1 STX
            }

            command.AddRange(Encoding.ASCII.GetBytes(obis)); //OBIS码

            command.Add(0x28); //左括号
            if (!string.IsNullOrEmpty(parameter))
            {
                command.AddRange(Encoding.ASCII.GetBytes(parameter)); //obis参数
            }
            command.Add(0x29); //右括号
            command.Add(0x03); //ETX

            //计算数据帧的BCC值
            byte bcc = IecBcc.Calculate(command.ToArray(), 1, command.Count - 1);
            command.Add(bcc); //BCC

            return command.ToArray();
        }

        /// <summary>
        /// 判断IEC帧是否完整
        /// </summary>
        /// <param name="buffer">数据帧</param>
        ///  <param name="dataLen">数据帧长度</param>
        /// <returns>true:完整帧 false:不完整帧</returns>
        private bool IsIecComplete(byte[] buffer, int dataLen)
        {
            //完整帧：STX () ETX BCC，长度至少为5
            if (dataLen < 5)
            {
                //判断是否为ACK:0x06
                int index = Array.IndexOf(buffer, (byte)0x06);
                if (index == -1)
                {
                    return false;
                }
                return true;
            }
          
            int head = Array.IndexOf(buffer, (byte)0x02);
            int tail = Array.IndexOf(buffer, (byte)0x03);

            if (head == -1 || tail == -1 || tail - head < 3)
            {
                return false;
            }

            return true;          
        }

        /// <summary>
        /// 解析异常应答帧，将错误码返回
        /// </summary>
        /// <param name="data">应答数据</param>
        /// <returns>错误码</returns>
        private int ParseExceptionResponse(string data)
        {
            if (!(data.Contains("ERR") && data.Length == 6))
            {
                throw new ArgumentException();              
            }
            return Convert.ToInt32(data.Substring(3, 3));
        }

        /// <summary>
        /// 等待加测板返回数据
        /// </summary>
        /// <param name="timeout">等待时间，以ms为单位</param>
        private bool WaitForByte(int timeout)
        {
            for (int timeLapsed = 0; timeLapsed < timeout; timeLapsed += 50)
            {
                System.Threading.Thread.Sleep(50);
       
                if (serialPort.BytesToRead > 0)
                {
                    return true;
                }               
            }
            return false;
        }
    }
}
