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

namespace Microstar.Production.PCBTest
{
    public class ApplicationSession
    {
        private static ApplicationSession applicationSession = null;
        private static readonly object locker = new object();

        public static ApplicationSession GetInstance()
        {
            if (applicationSession == null)
            {
                lock (locker)
                {
                    if (applicationSession == null)
                    {
                        applicationSession = new ApplicationSession();
                    }
                }
            }
            return applicationSession;
        }

        /// <summary>
        /// 防止直接调用构造函数
        /// </summary>
        private ApplicationSession()
        {

        }
    }
}
