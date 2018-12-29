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
    /// 继电器控制命令
    /// </summary>
    public sealed class RelayControlCommand : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(RelayControlCommand));

        /// <summary>
        /// 测量命令名字
        /// </summary>    
        public string Name
        {
            get { return Resources.Command_RelayControl; }
        }

        /// <summary>
        /// 检测命令OBIS码
        /// </summary>
        public string Obis
        {
            get { return "0-0:199.128.10"; }
        }

        /// <summary>
        /// 继电器控制命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            var relayParameter = parameter as RelayControlCommandParameter;
            if (parameter == null)
            {
                return false;
            }

            //序号可写为ALL，这时继电器动作只能是CLOSE
            if (relayParameter.SelectedNumber == "ALL")
            {
                if (relayParameter.Action.ToString() != "CLOSE")
                {
                    return false;
                }
            }
            else
            {
                if (int.TryParse(relayParameter.SelectedNumber, out int number))
                {
                    if (number < 0 || number > 21)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        /// <summary>
        /// 执行继电器控制命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var relayParameter = parameter as RelayControlCommandParameter;
            WriteResult writeResult = client.Write(Obis, FormatWriteParameter(relayParameter));

            var result = new CommandResult(writeResult.Success);

            if (!result.Success)
            {
                string message = string.Format(
                    Resources.RelayControlCommand_WriteFailedMessageFormat, 
                    this.Name, 
                    writeResult.Error.ToString(), 
                    relayParameter.ToString());

                logger.Error(message);
                throw new CommunicationException(message);           
            }

            return result;
        }

        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">继电器控制命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        private string FormatWriteParameter(RelayControlCommandParameter parameter)
        {
            return string.Format("{0},{1}", parameter.Action.ToString(), parameter.SelectedNumber);
        }
    }
}
