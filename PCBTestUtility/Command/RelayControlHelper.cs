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
using Microstar.Production.PCBTest.Properties;
using Microstar.Production.Comms;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 继电器控制帮助类
    /// </summary>
    public static class RelayControlHelper
    {
        public static CommandResult PulseRelayControl(PcbTesterClient client, RelayControlAction action)
        {      
            var relayControlCommand = new RelayControlCommand();
            var parameter = new RelayControlCommandParameter(action, "20");

            return relayControlCommand.Execute(client, parameter, null);
        }

        /// <summary>
        /// 上5V电
        /// </summary>
        /// <returns></returns>
        public static CommandResult On5V(PcbTesterClient client)
        {
            client.Open();
            var relayControlCommand = new RelayControlCommand();
            var relayParameter = new RelayControlCommandParameter(RelayControlAction.OPEN,"0");

            try
            {
                CommandResult result = relayControlCommand.Execute(client, relayParameter, null);
            }
            catch (CommunicationException ex)
            {
                throw new CommunicationException(ex.Message);
            }
            return new CommandResult(true);
        }

        /// <summary>
        /// 断电复位 关闭所有继电器
        /// </summary>
        /// <returns></returns>
        public static CommandResult Reset(PcbTesterClient client)
        {
            client.Open();
            var relayControlCommand = new RelayControlCommand();
            var relayParameter = new RelayControlCommandParameter(RelayControlAction.CLOSE, "ALL");

            try
            {
                CommandResult result = relayControlCommand.Execute(client, relayParameter, null);
            }
            catch (CommunicationException ex)
            {
                throw new CommunicationException(ex.Message);
            }
            return new CommandResult(true);
        }

        public static CommandResult ControlRelay(PcbTesterClient client,RelayControlCommandParameter relayParameter)
        {         
            client.Open();
            var relayControlCommand = new RelayControlCommand();

            try
            {
                CommandResult result = relayControlCommand.Execute(client, relayParameter, null);
            }
            catch (CommunicationException ex)
            {
                throw new CommunicationException(ex.Message);
            }
            return new CommandResult(true);
        }
    }
}
