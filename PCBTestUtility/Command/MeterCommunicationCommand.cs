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

using Microstar.Production.Comms.PCB;
using Microstar.Production.Comms;
using Microstar.Production.PCBTest.Properties;
using Microstar.Utility;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 与被测表通讯命令类
    /// </summary>
    public sealed class MeterCommunicationCommand : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MeterCommunicationCommand));

        /// <summary>
        /// 测量命令名字
        /// </summary>
        public string Name
        {
            get { return Resources.Command_MeterCommunication; }
        }

        /// <summary>
        /// 检测命令OBIS码
        /// </summary>
        public string Obis
        {
            get { return "0-0:199.128.9"; }
        }

        /// <summary>
        /// 被测表通信命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            var communicationParameter = parameter as MeterCommunicationCommandParameter;
            if (communicationParameter == null)
            {
                return false;
            }

            //波特率可设置为：300,600,1200,2400,4800,9600,19200, 38400
            if (communicationParameter.BaudRate < 300 || communicationParameter.BaudRate > 38400 || communicationParameter.BaudRate % 300 != 0)
            {
                return false;
            }

            //数据位可设置为：7,8
            if (!(communicationParameter.DataBits == 7 || communicationParameter.DataBits == 8))
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 执行被测表通信命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var communicationParameter = parameter as MeterCommunicationCommandParameter;

            //打开透明通道
            WriteResult writeResult = client.Write(Obis, FormatWriteParameter(communicationParameter));

            var result = new CommandResult(writeResult.Success);

            if (!result.Success)  //应答错误
            {
                string message = string.Format(
                    Resources.MeterCommunicationCommand_WriteFailedMessageFormat, 
                    this.Name, 
                    writeResult.Error.ToString(), 
                    communicationParameter.ToString());

                logger.Error(message);
                throw new CommunicationException(message);
            }

            byte[] recvData = client.Write(communicationParameter.SendData, communicationParameter.IsHex);
            string actualRecvData = Microstar.Utility.Hex.ToString(recvData, " ");
            string expectedRecvData = communicationParameter.ExpectedReceiveData.Trim();

            if (actualRecvData == expectedRecvData)
            {
                return new CommandResult(true, actualRecvData);
            }
            else
            {
                return new CommandResult(
                    false,
                    actualRecvData,
                    string.Format(
                        Resources.MeterCommunicationCommand_CommErrorMessageFormat,
                        this.Name,
                        communicationParameter.ToString(),
                        expectedRecvData,
                        actualRecvData));
            }
        }

        /// <summary>
        /// 组OBIS参数帧
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string FormatWriteParameter(MeterCommunicationCommandParameter parameter)
        { 
            return string.Format("{0},{1},{2},{3}", GetComPortFrame(parameter.ComPort), parameter.BaudRate, parameter.DataBits.GetHashCode(), parameter.Parity.ToString().Substring(0, 1));
        }

        /// <summary>
        /// 组端口名的帧（Enum里的跟实际发的端口名帧不一样，需要转换）
        /// </summary>
        /// <param name="comPort">Enum端口成员</param>
        /// <returns>转换后组帧的数据</returns>
        private string GetComPortFrame(CommunicationPort comPort)
        {
            switch (comPort)
            {
                case CommunicationPort.RS232:
                    {
                        return "232";
                    }
                case CommunicationPort.RS485_1:
                    {
                        return "485_1";
                    }
                case CommunicationPort.RS485_2:
                    {
                        return "485_2";
                    }
                case CommunicationPort.Optical:
                    {
                        return "GK";
                    }
                case CommunicationPort.Infrared:
                    {
                        return "HW";
                    }
                case CommunicationPort.PLC:
                    {
                        return "PLC";
                    }
                default:
                    {
                        return "485_1";
                    }
            }
        }
    }
}
