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
    /// 强制编程命令类单元测试
    /// </summary>
    [TestClass()]
    public class ForceProgramCommandTests : UnitTestBase
    {
        /// <summary>
        /// 执行强制编程命令
        /// </summary>
        [TestMethod()]
        public void ExcuteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();

                var command = new ForceProgramCommand();
                var parameter = new ForceProgramCommandParameter()
                {
                    I2CChipSelect = 0xA4,
                    I2CAddress = 0x4000,
                    SpiAddress = 0x00020000,
                    Length = 0x8000
                };
                
                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(result.Success, true);
                //Assert.AreEqual(result.Data, "ERR610");
                //Assert.AreEqual(result.Message, string.Format("({0}) {1}","ERR610",Resources.ERR610));
            }
        }
    }
}