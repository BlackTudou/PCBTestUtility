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

using Microstar.Production.PCBTest.Properties;
using System.IO;
using System.Text;
using System;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// 强制编程工具类
    /// </summary>
    public static class ForceProgramHelper
    {
        /// <summary>
        /// Spi起始地址
        /// </summary>
        public static readonly uint StartAddress = 0x00020000;

        /// <summary>
        /// 将字符串每两个字符拆分
        /// </summary>
        /// <param name="str">输入的字符串 形如："FFFFAC"</param>
        /// <returns>拆分后的字符串数组</returns>
        public static string[] SplitString(string str)
        {
            char[] charArray = str.ToCharArray();
            int i = 0;

            StringBuilder builder = new StringBuilder();

            foreach (char c in charArray)
            {
                builder.AppendFormat("{0:X}", c);
                i++;

                if (i % 2 == 0 && i < charArray.Length)
                {
                    builder.Append(" ");
                }

            }
            string temp = builder.ToString();

            return builder.ToString().Split(' ');
        }

        /// <summary>
        /// 根据选中的芯片号，计算SPI Flash地址
        /// </summary>
        /// <param name="chipNumber">芯片号</param>
        /// <returns>Flash地址</returns>
        public static uint CalculateSpiAddress(uint chipNumber)
        {
            if (chipNumber < Settings.Default.SpiCSLowerBound || chipNumber > Settings.Default.SpiCSUpperBound)
            {
                throw new ArgumentException(Resources.ForceProgramCommand_ChipNumberIllegal);
            }

            return (chipNumber - 1) * StartAddress;
        }

        /// <summary>
        /// 计算强编长度，UI传进来的是以kb为单位的，命令帧里是以字节为单位，需要转换下
        /// </summary>
        /// <param name="kBytes">字节数，以kb为单位</param>
        /// <returns>转换后的字节数</returns>
        public static uint CalculateForceProgramLength(uint kBytes)
        {
            if (!(kBytes == 32 || kBytes == 64))
            {
                throw new ArgumentException(Resources.ForceProgramCommand_LengthIllegal);
            }
            return kBytes * 1024;
        }
    }
}
