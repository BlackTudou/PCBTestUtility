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
    /// 强制编程状态
    /// </summary>
    public enum ForceProgramState
    {
        /// <summary>
        /// 正在强制编程中
        /// </summary>
        ForceProgramProcessing = 0,

        /// <summary>
        /// 成功结束
        /// </summary>
        Succeed = 1,

        /// <summary>
        /// 读Flash失败
        /// </summary>
        ERR604 = 604,

        /// <summary>
        /// 写I2C失败
        /// </summary>
        ERR610 = 610
    }
}
