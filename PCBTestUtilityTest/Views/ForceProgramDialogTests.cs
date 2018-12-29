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
using Microstar.Production.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microstar.Production.View.Tests
{
    [TestClass()]
    public class ForceProgramDialogTests
    {
        [TestMethod()]
        public void SplitStringTest()
        {
            //ForceProgramDialog.SplitString("FFFF1A2");
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateFileCheckSumTest()
        {
            //string temp = ForceProgramDialog.CalculateFileCheckSum(@"H:\WorkSpace\rPCBT\参考\newversion\256File\A211.BIN");
            //Assert.AreEqual("59BC2D7D", temp);
        }
    }
}