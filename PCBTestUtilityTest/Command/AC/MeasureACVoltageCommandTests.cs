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
using Microstar.Production.PCBTest.Properties;

namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 交流电压测量命令类单元测试
    /// </summary>
    [TestClass()]
    public class MeasureACVoltageCommandTests : UnitTestBase
    {
        /// <summary>
        /// 执行交流电压测量
        /// </summary>
        [TestMethod()]
        public void ExcuteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();

                var command = new MeasureACVoltageCommand();

                var parameter = new MeasureParameter(Phase.A)
                {
                    LowerLimit = 12m, //单位 V
                    UpperLimit = 50m
                };
              
                CommandResult result = command.Execute(client, parameter, null);

                Assert.AreEqual(false, result.Success);
                Assert.AreEqual("221.8V", result.Data);
                Assert.AreEqual("12V-50V;221.8V", result.Message);
            }
        }
    }
}