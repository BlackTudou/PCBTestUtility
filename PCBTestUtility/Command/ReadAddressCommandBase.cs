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
    /// 读地址操作基类
    /// </summary>
    public abstract class ReadAddressCommandBase : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ReadAddressCommandBase));

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
        /// 执行读取地址命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var addressParameter = parameter as AddressCommandParameter;

            ReadResult readResult = client.Read(Obis, FormatReadParameter(addressParameter));

            //检测结果为错误码
            if (!readResult.Success)
            {
                string messgae = string.Format(
                    Resources.ReadAddressCommandBase_ReadFailedMessageFormat, 
                    this.Name, 
                    readResult.Error.ToString(), 
                    addressParameter.ToString());

                logger.Error(messgae);
                throw new CommunicationException(messgae);
            }

            //将读到的值与期望值做比较
            if (readResult.Data == addressParameter.Data)
            {
                return new CommandResult(true, readResult.Data);
            }
            else
            {
                return new CommandResult(
                    false, 
                    readResult.Data, 
                    string.Format(
                        Resources.ReadAddressCommandBase_ReadErrorMessageFormat,
                        this.Name, 
                        addressParameter.Address, 
                        addressParameter.Length, 
                        addressParameter.Data, 
                        readResult.Data));
            }           
        }

        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">地址命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        protected abstract string FormatReadParameter(AddressCommandParameter parameter);
    }
}
