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
using Microstar.Production.PCBTest.Properties;


namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 测试检测板通信类PcbTesterClient
    /// </summary>
    [TestClass]
    public class PcbTesterClientTests : UnitTestBase
    {
        /// <summary>
        /// 正确应答
        /// </summary>
        [TestMethod]
        public void WriteSuccessTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                WriteResult writeResult = client.Write("0-0:199.128.1", string.Empty);
                Assert.AreEqual(true, writeResult.Success);
            }                         
        }
        /// <summary>
        /// 用串口工具回复错误应答信息，验证是否能正确解析出异常应答帧
        /// </summary>
        [TestMethod]
        public void WriteWrongTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                //启动交流测量命令，obis参数相线设置错误
                WriteResult writeResult = client.Write("0-0:199.128.5", "D");

                Assert.AreEqual(false, writeResult.Success);
                Assert.AreEqual(615, writeResult.Error.ErrorCode);

                Assert.AreEqual("(ERR615) "+ Resources.ERR615, writeResult.Error.ToString());
            }
        }

        [TestMethod()]
        public void WriteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
     
                byte[] writeResult = client.Write("68AAAAAAAAAAAA6801043413173A6916", true);
                Assert.Fail();
            }
        }
    }
}
