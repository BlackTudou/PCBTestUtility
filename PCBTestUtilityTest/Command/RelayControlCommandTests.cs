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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.Comms.PCB;
using Microstar.Production.PCBTest.Command;

namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 继电器控制命令类单元测试
    /// </summary>
    [TestClass()]
    public class RelayControlCommandTests : UnitTestBase
    {
        /// <summary>
        /// 关闭0，20继电器测试
        /// </summary>
        [TestMethod()]
        public void CloseRelayControlTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var relayControlCommand = new RelayControlCommand();

                var parameter = new RelayControlCommandParameter();
                parameter.Action = RelayControlAction.CLOSE;
                parameter.SelectedNumber = "0,20";
         
                var context = new CommandContext();

                CommandResult result = relayControlCommand.Execute(client, parameter, context);

                Assert.AreEqual(result.Success, true);
            }
        }

        /// <summary>
        /// 打开继电器测试
        /// </summary>
        [TestMethod()]
        public void OpenRelayControlTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var relayControlCommand = new RelayControlCommand();
                var parameter = new RelayControlCommandParameter();
                var context = new CommandContext();
                for (int i = 0; i < 22; i++)
                {
                    parameter.Action = RelayControlAction.OPEN;
                    parameter.SelectedNumber = i.ToString();

                    CommandResult result = relayControlCommand.Execute(client, parameter, context);

                    System.Threading.Thread.Sleep(500);

                    Assert.AreEqual(result.Success, true);
                }
            }
        }

        /// <summary>
        /// 关闭所有继电器
        /// </summary>
        [TestMethod()]
        public void CloseAllRelayControlTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var relayControlCommand = new RelayControlCommand();
                var parameter = new RelayControlCommandParameter();
                var context = new CommandContext();

                parameter.Action = RelayControlAction.CLOSE;
                parameter.SelectedNumber = "all";

                CommandResult result = relayControlCommand.Execute(client, parameter, context);
                Assert.AreEqual(result.Success, true);
            }        
        }
    }
}