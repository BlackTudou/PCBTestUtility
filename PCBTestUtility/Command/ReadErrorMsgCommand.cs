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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 读错误详细信息命令
    /// </summary>
    public class ReadErrorMsgCommand :  ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ReadErrorMsgCommand));

        public string Name => throw new System.NotImplementedException();

        public string Obis => throw new System.NotImplementedException();

        /// <summary>
        /// 读错误详细信息命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            return true;
        }

        /// <summary>
        /// 执行读错误详细信息命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var testResult = client.Read("0-0:199.128.12", string.Empty);

            //检测结果为错误码
            //if (!testResult.Contains(":") && testResult.Length == 6)
            //{
            //    logger.ErrorFormat("{0}", testResult);
           ////     throw new CommunicationException(testResult);
            //}

            return new CommandResult(true,testResult.Data);
        }
    }
}
