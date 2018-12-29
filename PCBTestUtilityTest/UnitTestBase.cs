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
namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 单元测试基类，记录串口的信息，一些测试用例共通的配置都可以放在这里
    /// </summary>
    public abstract class UnitTestBase
    {
        /// <summary>
        /// 端口号
        /// </summary>
        public string PortName
        {
            get
            {
                return "COM1";
            }
        }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate
        {
            get
            {
                return 19200;
            }
        }
    }
}
