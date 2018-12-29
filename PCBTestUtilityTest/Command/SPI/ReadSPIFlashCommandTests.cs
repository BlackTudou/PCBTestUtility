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
    /// 读检测板SPI Flash
    /// </summary>
    [TestClass()]
    public class ReadSPIFlashCommandTests : UnitTestBase
    {
        /// <summary>
        /// 执行读检测板SPI Flash命令
        /// </summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();

                var command = new ReadSPIFlashCommand();
               // var parameter = new AddressCommandParameter(0x00u, 2, "FFFF");
                //var parameter = new AddressCommandParameter(0x00020000u, 4, "FFFFFFFF");
                var parameter = new AddressCommandParameter(0x40, 0x40);

                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
                //Assert.AreEqual(result.Data, "126A9B63142533FFFFFFFFFFFFFFFFFF");
            }
        }
    }
}