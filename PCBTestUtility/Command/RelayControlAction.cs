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
    /// 继电器动作
    /// </summary>
    public enum RelayControlAction
    {
        /// <summary>
        /// 默认值
        /// </summary>
        ALL = 0,

        /// <summary>
        /// 关闭继电器
        /// </summary>
        CLOSE = 1,

        /// <summary>
        /// 打开继电器
        /// </summary>
        OPEN = 2
    }
}
