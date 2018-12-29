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
using System;
using System.Collections.Generic;
using System.Text;
using Microstar.Production.PCBTest.Properties;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 脉冲测量命令
    /// </summary>
    public sealed class MeasurePulseCommand : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MeasurePulseCommand));

        public string Name
        {
            get { return Resources.Command_MeasurePulse; }
        }

        public string Obis
        {
            get { return "0-0:199.128.1"; }
        }

        /// <summary>
        /// 脉冲检测命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            return true;
        }

        /// <summary>
        /// 执行脉冲检测命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            RelayControlHelper.On5V(client);

            StringBuilder sb = new StringBuilder();
           
            var relayControlPara = new RelayControlCommandParameter();
            relayControlPara.SelectedNumber = "20";

            RelayControlHelper.PulseRelayControl(client, RelayControlAction.OPEN);

            CommandResult commandResult = new CommandResult();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {   
                    relayControlPara.Action = RelayControlAction.OPEN;
                }
                else if (i == 1)
                {
                    relayControlPara.Action = RelayControlAction.CLOSE;        
                }

                //控制脉冲检测对应继电器               
                var relayControlCommand = new RelayControlCommand();
                commandResult = relayControlCommand.Execute(client, relayControlPara, context);

                //继电器操作失败
                if(!commandResult.Success)
                {
                    return commandResult;
                }
                System.Threading.Thread.Sleep(500);

                //发送检测命令
                WriteResult writeResult = client.Write("0-0:199.128.1", string.Empty);

                //启动脉冲采集命令异常应答
                if (!writeResult.Success)
                {
                    string message = string.Format("{0};0x{1:X};{2}", this.Name, string.Empty, writeResult.Error.ToString());
                    logger.ErrorFormat("{0}", message);
                    throw new CommunicationException(message);
                }
     
                //等待1s发送读取脉冲检测结果命令
                System.Threading.Thread.Sleep(1000);
                ReadResult testResult = client.Read("0-0:199.128.1", string.Empty);
         
                //检测结果为错误码
                if (!testResult.Success)
                {
                    logger.ErrorFormat("{0}", testResult.Data);
                    throw new CommunicationException(testResult.Data);              
                }

                commandResult.Success = true;
                sb.Append(testResult);              
                if (i == 0)
                {
                    sb.Append(",");
                }                          
            }
            commandResult.Data = sb.ToString();
            return commandResult;
        }

        /// <summary>
        /// 获取8路脉冲整形计数值
        /// </summary>
        /// <param name="testPulseResult">脉冲计数值</param>
        /// <returns>8路脉冲整形值</returns>
        public int[] GetPulseValue(string testPulseResult)
        {
            List<int> result = new List<int>();

            string[] pulseValue = testPulseResult.Split(',');
            foreach (string item in pulseValue)
            {
                result.Add(Convert.ToInt32(item));
            }

            return result.ToArray();
        }
    }
}
