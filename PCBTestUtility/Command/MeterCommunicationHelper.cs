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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microstar.Production.Comms.PCB;
using Microstar.Production.Comms;
using Microstar.Production.PCBTest.Properties;
using Microstar.Utility;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 与被测表通信帮助类
    /// </summary>
    public static class MeterCommunicationHelper
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MeterCommunicationHelper));

        /// <summary>
        /// 开启透明通道
        /// </summary>
        /// <param name="client">PcbTesterClient实例</param>
        /// <param name="parameter">端口参数</param>
        /// <returns>运行结果</returns>
        public static CommandResult OpenTransparentChannel(PcbTesterClient client, CommandParameter parameter)
        {
            var communicationParameter = parameter as MeterCommunicationCommandParameter;
            MeterCommunicationCommand command = new MeterCommunicationCommand();

            //打开透明通道
            WriteResult writeResult = client.Write(command.Obis, command.FormatWriteParameter(communicationParameter));
            var result = new CommandResult(writeResult.Success);

            if (!result.Success)  //应答错误
            {
                string message = string.Format(
                    Resources.MeterCommunicationCommand_WriteFailedMessageFormat,
                    command.Name,
                    writeResult.Error.ToString(),
                    communicationParameter.ToString());
                logger.Error(message);
                throw new CommunicationException(message);
            }

            return result;
        }

        /// <summary>
        /// 退出透明通道
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        public static void ExitTransparentChannel(PcbTesterClient client)
        {
            client.Write(MinistryStandardFrames.ExitTransparentChannel, true);
        }
    }
}
