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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 写地址操作基类
    /// </summary>
    public abstract class WriteAddressCommandBase : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(WriteAddressCommandBase));

        /// <summary>
        /// 测量命令名字
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 检测命令OBIS码
        /// </summary>
        public abstract string Obis { get; }

        /// <summary>
        /// 检测命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public virtual bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            var addressParameter = parameter as AddressCommandParameter;

            if (addressParameter == null)
            {
                return false;
            }

            if (addressParameter.Data.Length != addressParameter.Length)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 写地址命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var addressParameter = parameter as AddressCommandParameter;

            WriteResult writeResult = client.Write(Obis, FormatWriteParameter(addressParameter));

            var result = new CommandResult(writeResult.Success);

            if (!result.Success)
            {
                string message = string.Format(
                    Resources.WriteAddressCommandBase_WriteFailedMessageFormat, 
                    this.Name, 
                    writeResult.Error.ToString(), 
                    addressParameter.ToString());

                logger.Error(message);
                throw new CommunicationException(message);
            }

            return result;
        }

        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">地址命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        protected abstract string FormatWriteParameter(AddressCommandParameter parameter);
    }
}
