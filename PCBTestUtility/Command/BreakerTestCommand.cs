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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 断路器检测命令
    /// </summary>
    public sealed class BreakerTestCommand : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BreakerTestCommand));

        public string Name => throw new System.NotImplementedException();

        public string Obis => throw new System.NotImplementedException();

        /// <summary>
        /// 断路器检测命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            if (parameter == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 执行断路器检测命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            WriteResult writeResult = client.Write("0-0:199.128.11", string.Empty);

            if (!writeResult.Success)
            {
                string message = string.Format("{0};0x{1:X};{2}", Resources.BreakerTest, string.Empty, writeResult.Error.ToString());
                logger.ErrorFormat("{0}", message);
                throw new CommunicationException(message);            
            }

            ReadResult testResult = client.Read("0-0:199.128.11", string.Empty);

            //检测结果为错误码
            if (!testResult.Success)
            {
                logger.ErrorFormat("{0}", testResult.Data);
                throw new CommunicationException(testResult.Data);
            }

            //检测板支持三路断路器检测，三路检测结果用逗号隔开，取值为“OK”/“ERROR”。e.g. OK,ERROR,ERROR
            string[] breakerState = testResult.Data.Split(',');
            for (int i = 0; i < breakerState.Length; i++)
            {
                if (breakerState[i] == "ERROR")
                {
                    return new CommandResult(false, testResult.Data);
                }
            }

            return new CommandResult(true, testResult.Data);
        }   
    }
}
