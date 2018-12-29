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

namespace Microstar.Production.Comms.PCB
{
    /// <summary>
    /// IEC BCC帮助类
    /// </summary>
    public static class IecBcc
    {
        /// <summary>
        /// 计算BCC值
        /// </summary>
        /// <param name="bytes">当前数据帧</param>
        /// <param name="startIndex">起始下标</param>
        /// <param name="endIndex">结束下标</param>
        /// <returns>计算的BCC值</returns>
        public static byte Calculate(byte[] bytes, int startIndex, int endIndex)
        {
            byte bcc = 0x00;

            for (int i = startIndex; i <= endIndex; i++)
            {
                bcc ^= bytes[i];
            }

            return bcc;
        }
    }
}
