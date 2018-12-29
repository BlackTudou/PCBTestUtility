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
    /// 部标协议帧
    /// </summary>
    public static class MinistryStandardFrames
    {
        /// <summary>
        /// 退出透明通道部标帧
        /// </summary>
        public static readonly string ExitTransparentChannel = "68 11 11 11 11 11 11 68 04 06 06 EA 00 00 00 00 30 16";

        /// <summary>
        /// 激活表秒信号部标帧
        /// </summary>
        public static readonly string ActivateSecond = "68 AA AA AA AA AA AA 68 01 04 34 13 17 3A 69 16";

        /// <summary>
        /// 读部标信息
        /// </summary>
        public static readonly string ReadMeterMessage = "68 AA AA AA AA AA AA 68 01 04 34 13 17 3A 69 16";
    }
}
