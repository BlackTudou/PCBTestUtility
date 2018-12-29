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

namespace Microstar.Production.PCBTest.Command.Tests
{
    [TestClass()]
    public class MeterCommunicationCommandTests
    {
        [TestMethod()]
        public void OpenTransparentChannelTest()
        {
            Assert.Fail();
        }
    }
}

namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 被测表通信命令单元测试
    /// </summary>
    [TestClass()]
    public class MeterCommunicationCommandTests : MeterCommunicationCommandTestsBase
    {
        /// <summary>
        /// RS485_1通信测试
        /// </summary>
        [TestMethod()]
        public void RS485_1Test()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var command = new MeterCommunicationCommand();
                var parameter = new MeterCommunicationCommandParameter();

                parameter.ComPort  = CommunicationPort.RS485_1;
                parameter.BaudRate = MeterBaudRate;
                parameter.DataBits = MeterDataBits;
                parameter.Parity = MeterParity;

                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
            }
        }

        /// <summary>
        /// RS485_2通信测试
        /// </summary>
        [TestMethod()]
        public void RS485_2Test()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var command = new MeterCommunicationCommand();
                var parameter = new MeterCommunicationCommandParameter();

                parameter.ComPort = CommunicationPort.RS485_2;
                parameter.BaudRate = MeterBaudRate;
                parameter.DataBits = MeterDataBits;
                parameter.Parity = MeterParity;

                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
            }
        }


        /// <summary>
        /// RS232通信测试
        /// </summary>
        [TestMethod()]
        public void RS232Test()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var command = new MeterCommunicationCommand();
                var parameter = new MeterCommunicationCommandParameter();

                parameter.ComPort = CommunicationPort.RS232;
                parameter.BaudRate = MeterBaudRate;
                parameter.DataBits = MeterDataBits;
                parameter.Parity = MeterParity;

                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
            }
        }

        /// <summary>
        /// 光口通信测试
        /// </summary>
        [TestMethod()]
        public void GKTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var command = new MeterCommunicationCommand();
                var parameter = new MeterCommunicationCommandParameter();

                parameter.ComPort = CommunicationPort.Optical;
                parameter.BaudRate = MeterBaudRate;
                parameter.DataBits = MeterDataBits;
                parameter.Parity = MeterParity;

                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
            }
        }

        /// <summary>
        /// 红外通信测试
        /// </summary>
        [TestMethod()]
        public void HWTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var command = new MeterCommunicationCommand();
                var parameter = new MeterCommunicationCommandParameter();

                parameter.ComPort = CommunicationPort.Infrared;
                parameter.BaudRate = MeterBaudRate;
                parameter.DataBits = MeterDataBits;
                parameter.Parity = MeterParity;

                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
            }
        }
    }
}