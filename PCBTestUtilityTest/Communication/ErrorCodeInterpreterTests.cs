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
using System.Globalization;
using System.Threading;

namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// ErrorCode转ErrorMessage函数测试
    /// </summary>
    [TestClass()]
    public class ErrorCodeInterpreterTests
    {
        /// <summary>
        /// Interpret函数测试，将整形错误码解释为详细的错误信息
        /// </summary>
        [TestMethod()]
        public void InterpretTest()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            string temp1 = Resources.ERR001;
            Assert.AreEqual(Resources.ERR001, ErrorCodeInterpreter.Interpret(1));
            Assert.AreEqual(Resources.ERR600, ErrorCodeInterpreter.Interpret(600));
            Assert.AreEqual(Resources.ERR610, ErrorCodeInterpreter.Interpret(610));
            Assert.AreEqual(Resources.ERR615, ErrorCodeInterpreter.Interpret(615));
            Assert.AreEqual(Resources.ERR620, ErrorCodeInterpreter.Interpret(620));
        }
    }
}