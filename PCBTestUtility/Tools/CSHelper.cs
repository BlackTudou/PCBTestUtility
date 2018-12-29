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

using System.IO;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// 计算CS校验帮助类
    /// </summary>
    public static class CSHelper
    {
        /// <summary>
        /// 计算文件CS和
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>校验和</returns>
        public static byte CalculateFileCS(string fileName)
        {
            using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] readBytes = binaryReader.ReadBytes((int)stream.Length);

                int cs = 0;
                foreach (byte b in readBytes)
                {
                    cs += b;
                }
                cs = cs % 0x100; //保留最后两位

                return (byte)cs;
            }
        }

        /// <summary>
        /// 计算Hex数组CS和
        /// </summary>
        /// <param name="bytes">hex 数组</param>
        /// <param name="startIndex">开始下标</param>
        /// <param name="length">计算长度</param>
        /// <returns>CS累加和</returns>
        public static byte CalculateCS(byte[] bytes, int startIndex, int length)
        {
            int cs = 0;
            for (int i = startIndex; i < startIndex + length; i++)
            {
                cs += bytes[i];
            }

            cs = cs % 0x100; //保留最后两位

            return (byte)cs;
        }

        /// <summary>
        /// 计算Hex数组CS和
        /// </summary>
        /// <param name="bytes">hex数组</param>
        /// <returns>CS和</returns>
        public static byte CalculateCS(byte[] bytes)
        {
            return CalculateCS(bytes, 0, bytes.Length);
        }

    }
}
