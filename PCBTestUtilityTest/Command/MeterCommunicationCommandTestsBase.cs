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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Microstar.Production.PCBTest.Tests
{
    public abstract class MeterCommunicationCommandTestsBase : UnitTestBase
    {
        public int MeterBaudRate
        {
            get { return 9600; }
        }

        public int MeterDataBits
        {
            get { return 8; }
        }

        public Parity MeterParity
        {
            get { return Parity.None; }
        }
    }
}
