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
using Microstar.Production.PCBTest.Command;
using Microstar.Production.PCBTest.Model;
using System;

namespace Microstar.Production.PCBTest.Business
{
    /// <summary>
    /// 命令执行引擎
    /// </summary>
    public sealed class CommandEngine
    {
        private static readonly Lazy<CommandEngine> instance = new Lazy<CommandEngine>(() => new CommandEngine());
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CommandEngine));

        /// <summary>
        /// CommandEngine类的实例
        /// </summary>
        public static CommandEngine Instance
        {
            get
            {
                return instance.Value;
            }
        }
        
        /// <summary>
        ///  防止直接调用构造函数
        /// </summary>
        private CommandEngine()
        { }

        /// <summary>
        /// 执行Commandl类Excute函数
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="testItem">选中的检测项</param>
        /// <returns>检测结果</returns>
        public CommandResult Excute(PcbTesterClient client, TestItemInfo testItem)
        {           
            var command = ProfileManager.Instance.GetCommand(testItem.Name);

            var commandResult = new CommandResult();
            try
            {
                commandResult = command.Execute(client, testItem.Parameter, null);
                logger.InfoFormat("Run test:{0}...", testItem.Name);               
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Run test:{0}; Exception message:{1}.", testItem.Name, ex.Message);
                throw new Exception(ex.Message);
            }

            return commandResult;
        }     
    }
}
