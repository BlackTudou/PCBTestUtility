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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microstar.Production.View
{
    public class TransmitBinFile
    {
        /// <summary>
        /// 写入的SPI地址
        /// </summary>
        public uint SpiAddress { get; set; }

        /// <summary>
        /// 写入的二进制文件数据
        /// </summary>
        public byte[] FileData { get; set; }

        public int Length { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public TransmitBinFile()
        { }

        /// <summary>
        /// 初始化SPI地址，写入的二进制文件数据
        /// </summary>
        /// <param name="spiAddress"></param>
        /// <param name="fileData"></param>
        public TransmitBinFile(uint spiAddress, byte[] fileData)
        {
            SpiAddress = spiAddress;
            FileData = fileData;
        }
    }
}
