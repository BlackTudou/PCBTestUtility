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
    /// 通信端口方式
    /// </summary>
    public enum CommunicationPort
    {
        /// <summary>
        /// 485_1端口
        /// </summary>
        RS485_1 = 0,

        /// <summary>
        /// 485_2端口
        /// </summary>
        RS485_2 = 1,

        /// <summary>
        /// 232端口
        /// </summary>
        RS232 = 2,

        /// <summary>
        /// 光口通讯端口
        /// </summary>
        Optical = 3,

        /// <summary>
        /// 红外通讯端口
        /// </summary>
        Infrared = 4,

        /// <summary>
        /// PLC端口
        /// </summary>
        PLC = 5
    }
}
