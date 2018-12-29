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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    ///  直流电流测量量程
    /// </summary>
    public enum CurrentRange
    {
        /// <summary>
        /// Unknown或者Default等特殊值
        /// </summary>
        All = 0,

        /// <summary>
        /// 小量程
        /// </summary>
        Small = 1,

        /// <summary>
        /// 中等量程
        /// </summary>
        Medium = 2,

        /// <summary>
        /// 大量程
        /// </summary>
        Large = 3
    }
}
