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

namespace Microstar.Production.Tools
{
    /// <summary>
    /// 计算CRC8帮助类 (CRC8/MAXIM x8+x5+x4+1)
    /// </summary>
    public static class CRC8Helper
    {
        /// <summary> 
        /// CRC 8 位校验表 
        /// </summary> 
        private static readonly byte[] crc8Table = new byte[]
        {
            0,94,188,226,97,63,221,131,194,156,126,32,163,253,31,65,
            157,195,33,127,252,162,64,30, 95,1,227,189,62,96,130,220,
            35,125,159,193,66,28,254,160,225,191,93,3,128,222,60,98,
            190,224,2,92,223,129,99,61,124,34,192,158,29,67,161,255,
            70,24,250,164,39,121,155,197,132,218,56,102,229,187,89,7,
            219,133,103,57,186,228,6,88,25,71,165,251,120,38,196,154,
            101,59,217,135,4,90,184,230,167,249,27,69,198,152,122,36,
            248,166,68,26,153,199,37,123,58,100,134,216,91,5,231,185,
            140,210,48,110,237,179,81,15,78,16,242,172,47,113,147,205,
            17,79,173,243,112,46,204,146,211,141,111,49,178,236,14,80,
            175,241,19,77,206,144,114,44,109,51,209,143,12,82,176,238,
            50,108,142,208,83,13,239,177,240,174,76,18,145,207,45,115,
            202,148,118,40,171,245,23,73,8,86,180,234,105,55,213,139,
            87,9,235,181,54,104,138,212,149,203, 41,119,244,170,72,22,
            233,183,85,11,136,214,52,106,43,117,151,201,74,20,246,168,
            116,42,200,150,21,75,169,247,182,232,10,84,215,137,107,53
        };

        /// <summary>
        /// 8位CRC校验 产生校验码
        /// </summary>
        /// <param name="data">被校验码</param>
        /// <param name="crc">校验码</param>
        /// <returns>产生新的校验码</returns>
        public static byte CalculateCRC8(byte data, byte crc)
        {
            return crc8Table[crc ^ data];
        }

        /// <summary>
        /// 计算byte数组CRC8 校验码
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="startIndex">开始下标</param>
        /// <param name="length">需要计算的长度</param>
        /// <returns>校验码</returns>
        public static byte CalculateCRC8(byte[] bytes, int startIndex, int length)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("buffer");
            }

            if (startIndex < 0 || length < 0 || startIndex + length > bytes.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            int crc = 0;
            for (int i = startIndex; i < startIndex + length; i++)
            {
                crc = crc8Table[crc ^ bytes[i]];
            }
            return (byte)crc;
        }

        /// <summary>
        /// 计算整个byte数组校验码
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns>校验码</returns>
        public static byte CalculateCRC8(byte[] bytes)
        {
            return CalculateCRC8(bytes, 0, bytes.Length);
        }
    }
}   
