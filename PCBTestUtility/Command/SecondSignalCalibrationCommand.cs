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

using Microstar.Production.Comms;
using Microstar.Production.Comms.PCB;
using Microstar.Production.PCBTest.Properties;
using System;
using System.Text;
using System.Linq;
using Microstar.Production.Tools;
using System.Collections.Generic;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 秒信号检测命令类
    /// </summary>
    public sealed class SecondSignalCalibrationCommand  :  ICommand
    {
        public static readonly decimal baseNumber = 10000000m;
        public static readonly decimal divideNumber = 10m;
        public static readonly decimal noValue = -1000000m;

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SecondSignalCalibrationCommand ));   

        /// <summary>
        /// 测量命令名字
        /// </summary>
        public string Name
        {
            get { return Resources.Command_SecondSignalCalibration; }
        }

        /// <summary>
        /// 检测命令OBIS码
        /// </summary>
        public string Obis
        {
            get { return "0-0:199.128.2"; }
        }

        /// <summary>
        /// 秒信号检测命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            var secondParameter = parameter as SecondSignalCalibrationParameter;
            if (secondParameter == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 执行秒信号检测命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var secondParameter = parameter as SecondSignalCalibrationParameter;

            while (true)
            {
                RelayControlHelper.On5V(client);

                if (secondParameter.EnableActivateClockSignal)  //如果需要激活表秒信号功能
                {
                    logger.Debug("Activate second signal...");
                    ActivateSecond(client, secondParameter);                   
                }

                logger.Debug("Start test second signal...");
                WriteResult writeResult = client.Write(Obis, string.Empty);

                //开始检测秒信号失败
                if (!writeResult.Success)
                {
                    string message = string.Format(
                        Resources.SecondSignalCalibrationCommand_WriteFailedMessageFormat,
                        this.Name,
                        writeResult.Error.ToString(),
                        string.Empty);

                    logger.Error(message);
                    throw new CommunicationException(message);
                }
                //等待发送读取秒信号检测结果命令
                System.Threading.Thread.Sleep((int)secondParameter.DelayTime);

                logger.Debug("Read test second signal result...");
                ReadResult readResult = client.Read(Obis, string.Empty); //发送读秒信号检测结果帧

                //检测结果为错误码
                if (!readResult.Success)
                {
                    string message = string.Format(
                        Resources.SecondSignalCalibrationCommand_ReadResultFailedMessageFormat,
                        this.Name,
                        readResult.Error.ToString(),
                        string.Empty);

                    logger.Error(message);
                    throw new CommunicationException(message);
                }
                decimal clockValue = ParseClockSignalResult(readResult.Data);

                if (clockValue == noValue) //无秒信号值
                {
                    logger.Error(Resources.SecondSignalCalibrationCommand_NoValue);
                    throw new CommunicationException(Resources.SecondSignalCalibrationCommand_NoValue);
                }

                //结果在误差范围内 正确结果
                if (secondParameter.IsWithinRange(clockValue))
                {
                    return new CommandResult(true, readResult.Data);
                }

                //秒信号错误，不在误差范围内，判断是否需要补偿秒信号
                if (!secondParameter.EnableAutoClockCompensation) // 不需要补偿，返回错误结果
                {
                    string expectedValue = secondParameter.ExpectedValueRange;

                    return new CommandResult(
                        false,
                        readResult.Data,
                        string.Format(
                            Resources.SecondSignalCalibrationCommand_MeasureErrorMessageFormat,
                            this.Name,
                            secondParameter.ToString(),
                            secondParameter.ExpectedValueRange,
                            readResult.Data));
                }

                logger.Debug("Compensate second signal...");
                //补偿秒信号
                CompensateClockSignal(client, secondParameter, clockValue);
            }
        }


        /// <summary>
        /// 解析检测板回的秒信号结果帧，转为可比较的结果
        /// </summary>
        /// <param name="readResult">检测板回复的结果</param>
        /// <returns>转换后的结果</returns>
        private decimal ParseClockSignalResult(string readResult)
        {
            string[] resultArray = readResult.Split(',');
            if (resultArray.Length != 2)
            {
                return -1;
            }

            decimal clockNumber = Convert.ToDecimal(resultArray[0]);   //秒信号个数 
            decimal latchCountValue = Convert.ToDecimal(resultArray[1]); //锁存器计数值

            decimal result = 0m;

            try
            {
                result = ((latchCountValue / (clockNumber)) - baseNumber) / divideNumber;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Clock number is zero.");
            }
            return result;
        }

        /// <summary>
        /// 激活表的秒信号
        /// </summary>
        /// <returns></returns>
        private void ActivateSecond(PcbTesterClient client, SecondSignalCalibrationParameter parameter)
        {
            //1.开透明通道
            MeterCommunicationCommand communicationCommand = new MeterCommunicationCommand();

            var communicationParamter = new MeterCommunicationCommandParameter(
                parameter.ComPort, 
                parameter.BaudRate, 
                parameter.DataBits, 
                parameter.Parity);

            MeterCommunicationHelper.OpenTransparentChannel(client, communicationParamter);
         
            //2.发送激活秒信号帧
            client.Write(MinistryStandardFrames.ActivateSecond, true); //激活秒信号帧

            //3.发完退出透明通道
            MeterCommunicationHelper.ExitTransparentChannel(client); //退出透明通道
        }


        /// <summary>
        /// 补偿秒信号
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">秒信号参数</param>
        /// <param name="clockValue"></param>
        private void CompensateClockSignal(PcbTesterClient client, SecondSignalCalibrationParameter parameter, decimal clockValue)
        {
            //1.开透明通道
            MeterCommunicationCommand communicationCommand = new MeterCommunicationCommand();
            
            var openResult = MeterCommunicationHelper.OpenTransparentChannel(
                client, 
                new MeterCommunicationCommandParameter(
                    parameter.ComPort,
                    parameter.BaudRate,
                    parameter.DataBits,
                    parameter.Parity));

            //2.发送读部标信息帧
            byte[] resultBuffer = client.Write(MinistryStandardFrames.ReadMeterMessage, true);

            //3.处理表回的信息帧
            int b = resultBuffer[14] - 0x33;

            if ((b & 0x40) != 0)
            {
                b = b | 0x80;
            }
            int complementCode = (int)ComplementCodeHelper.CalcComplementCode(clockValue);
            int sendComplementCode = (b + complementCode) & 0x7F;

            //秒信号无法修补
            if (!((0x00 <= sendComplementCode && sendComplementCode <= 0x0A) || (0x70 <= sendComplementCode && sendComplementCode <= 0x7F)))
            {
                MeterCommunicationHelper.ExitTransparentChannel(client); //退出透明通道
                return;
            }

            //4.若能补偿，则发送补偿秒信号的帧
            string clockChipFrame = GetWriteClockChipFrame((byte)sendComplementCode); //写时钟芯片信号帧
            client.Write(clockChipFrame, true);

            string compensateClockSignalFrame = GetCompensateClockSignalFrame((byte)sendComplementCode);
            client.Write(clockChipFrame, true);

            MeterCommunicationHelper.ExitTransparentChannel(client); //退出透明通道
        }

        /// <summary>
        /// 组写时钟芯片信号帧
        /// </summary>
        /// <param name="complementCode">补偿秒信号的码</param>
        /// <returns></returns>
        public string GetWriteClockChipFrame(byte complementCode)
        {
            List<byte> sendBuffer = new List<byte>();
            sendBuffer.AddRange(Microstar.Utility.Hex.FromString("68AAAAAAAAAAAA680409341333999999A330"));
            sendBuffer.Add(complementCode);

            byte cs = CSHelper.CalculateCS(sendBuffer.ToArray());
            sendBuffer.Add(cs);
            sendBuffer.Add(0x16);

            return Microstar.Utility.Hex.ToString(sendBuffer.ToArray());
        }

        /// <summary>
        /// 组补秒信号帧
        /// </summary>
        /// <param name="complementCode">补偿秒信号的码</param>
        /// <returns></returns>
        private string GetCompensateClockSignalFrame(byte complementCode)
        {
            List<byte> sendBuffer = new List<byte>();
            sendBuffer.AddRange(Microstar.Utility.Hex.FromString("68AAAAAAAAAAAA68040A341333999999173A"));
            sendBuffer.Add(complementCode);

            byte crc = CRC8Helper.CalculateCRC8((byte)(complementCode - 0x33), 0xFF);
            crc = (byte)(crc + 0x33);
            sendBuffer.Add(crc); //CRC8

            byte cs = CSHelper.CalculateCS(sendBuffer.ToArray());
            sendBuffer.Add(cs);
            sendBuffer.Add(0x16);

            return Microstar.Utility.Hex.ToString(sendBuffer.ToArray());
        }
    }
}
