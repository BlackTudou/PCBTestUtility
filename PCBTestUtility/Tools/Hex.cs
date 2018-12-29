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
using System.Text;
using System.IO;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// Hex帮助类
    /// </summary>
    public static class Hex
    {
        /// <summary>
        /// 将byte数组转换为hex string
        /// </summary>
        /// <param name="bytes">需要转换的byte数组</param>
        /// <param name="offset">bytes 参数中从零开始的字节偏移量，从此处开始将字节转换为hex string。</param>
        /// <param name="length">要转换的字节数</param>
        /// <returns></returns>
        public static string ToString(byte[] bytes, int offset, int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = offset; i < offset + length - 1; i++)
            {
                sb.AppendFormat("{0:X2} ", bytes[i]);
            }
            sb.AppendFormat("{0:X2}", bytes[offset + length - 1]); //最后一个byte后面不加空格

            return sb.ToString();
        }

        /// <summary>
        /// 将hex string转为byte数组
        /// </summary>
        /// <param name="hexString">hex string</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] FromString(string hexString)
        {
            if (hexString == null)
            {
                return null;
            }

            if (hexString.Length == 0)
            {
                return new byte[0];
            }

            hexString = hexString.Trim().Replace(" ", "");

            int NumberChars = hexString.Length / 2;
            byte[] bytes = new byte[NumberChars];
            using (var sr = new StringReader(hexString))
            {
                for (int i = 0; i < NumberChars; i++)
                    bytes[i] =
                      Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
            }
            return bytes;
        }

        /// <summary>
        /// 把int类型转换为4字节16进制显示
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Int2Hex4(uint num)
        {
            byte[] temp = new byte[8];
            num &= 0xffffffff;//保留32位

            for (int i = 7; i >= 0; i--)
            {
                temp[i] = (byte)(num & 0x0f);
                if (temp[i] < 10)
                {
                    temp[i] += (byte)'0';
                }
                else
                {
                    temp[i] -= 10;
                    temp[i] += (byte)'a';
                }
                num >>= 4;
            }
            return Encoding.ASCII.GetString(temp);
        }

        /// <summary>
        /// byte转1字节16进制
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Byte2Hex1(byte num)
        {
            byte[] temp = new byte[2];
            temp[0] = (byte)(((uint)num >> 4) & 0x0f);
            if (temp[0] < 10)
            {
                temp[0] += (byte)'0';
            }
            else
            {
                temp[0] -= 10;
                temp[0] += (byte)'A';
            }

            temp[1] = (byte)((uint)num & 0x0f);
            if (temp[1] < 10)
            {
                temp[1] += (byte)'0';
            }
            else
            {
                temp[1] -= 10;
                temp[1] += (byte)'A';
            }

            return Encoding.ASCII.GetString(temp);
        }
    }
}
