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
    /// 有功功率测量命令类单元测试
    /// </summary>
    [TestClass()]
    public class MeasureActivePowerCommandTests : UnitTestBase
    {
        /// <summary>
        /// 执行有功功率测量
        /// </summary>
        [TestMethod()]
        public void ExcuteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var command = new MeasureActivePowerCommand();

                var parameter = new MeasureParameter(Phase.A)
                {         
                    LowerLimit = -2.2m,
                    UpperLimit = 2.2m
                };
            
                CommandResult result = command.Execute(client, parameter, null);
           
                Assert.AreEqual(true, result.Success);
                Assert.AreEqual("1.498W", result.Data);
            }
        }
    }
}