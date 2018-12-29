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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 强编命令参数
    /// </summary>
    [Serializable]
    public class ForceProgramCommandParameter : CommandParameter
    {
        /// <summary>
        /// I2C片选码，当片选码为0xFF时，读取RN8215内部EEPROM。
        /// </summary>
        public byte I2CChipSelect { get; set; }

        /// <summary>
        /// I2C地址，I2C地址取值范围是0x0000-0xFFFF。
        /// </summary>
        public uint I2CAddress { get; set; }

        /// <summary>
        /// SPI地址
        /// </summary>
        public uint SpiAddress { get; set; }

        /// <summary>
        /// 读取长度
        /// </summary>
        public uint Length { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ForceProgramCommandParameter()
        { }

        /// <summary>
        /// 强编初始化
        /// </summary>
        /// <param name="i2CChipSelect">I2C片选码</param>
        /// <param name="i2CAddress">I2C地址</param>
        /// <param name="spiAddress">SPI地址</param>
        /// <param name="length">读取长度</param>
        public ForceProgramCommandParameter(byte i2CChipSelect, uint i2CAddress, uint spiAddress, uint length)
        {
            I2CChipSelect = i2CChipSelect;
            I2CAddress = i2CAddress;
            SpiAddress = spiAddress;
            Length = length;
        }

        /// <summary>
        /// 将强编参数转为字符串
        /// </summary>
        /// <returns>字符串形式OBIS参数</returns>
        public override string ToString()
        {
            return string.Format("I2CChipSelect = 0x{0:X2}, I2CAddress = 0x{1:X4}, SpiAddress = 0x{2:X8}, Length = 0x{3:X8}", I2CChipSelect, I2CAddress, SpiAddress, Length);
        }
    }
}
