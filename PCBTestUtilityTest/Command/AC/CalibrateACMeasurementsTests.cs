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
    /// 交流测量校正命令类单元测试
    /// </summary>
    [TestClass()]
    public class CalibrateACMeasurementsTests : UnitTestBase
    {
        /// <summary>
        /// 校正电压测量值
        /// </summary>
        [TestMethod()]
        public void CalibrateACCurrentTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();

                WriteResult writeResult = CalibrationHelper.CalibrateCurrent(client, 14.58m);
                //Assert.AreEqual(writeResult.Success, true);

                Assert.AreEqual(writeResult.Success, false);
                Assert.AreEqual(writeResult.Error.ErrorCode, 615);
                Assert.AreEqual(writeResult.Error.Message, "Calibrate AC Current Measurement");
                Assert.AreEqual(writeResult.Error.ToString(), string.Format("(ERR615) {0}", Resources.ERR615));
            }
        }

        /// <summary>
        /// 校正电流测量值
        /// </summary>
        [TestMethod()]
        public void CalibrateACVoltageTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();

                WriteResult writeResult = CalibrationHelper.CalibrateVoltage(client, 221.1m);
                Assert.AreEqual(writeResult.Success, true);
            }
        }

        /// <summary>
        /// 校正相位
        /// </summary>
        [TestMethod()]
        public void CalibrateACPhaseTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();

                WriteResult writeResult = CalibrationHelper.CalibratePhase(client, 65);
                Assert.AreEqual(writeResult.Success, true);
            }
        }
    }
}