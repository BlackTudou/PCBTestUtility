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
    /// 测量相线
    /// </summary>
    public enum Phase
    {
        /// <summary>
        /// Unknown或者Default等特殊值
        /// </summary>
        All = 0,

        /// <summary>
        /// A相线
        /// </summary>
        A = 1,

        /// <summary>
        /// B相线
        /// </summary>
        B = 2,

        /// <summary>
        /// C相线
        /// </summary>
        C = 3
    }
}
