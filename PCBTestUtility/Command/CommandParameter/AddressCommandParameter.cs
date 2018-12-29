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
    /// 地址参数类
    /// </summary>
    public class AddressCommandParameter :  CommandParameter
    {
        /// <summary>
        /// 片选码
        /// </summary>
        public byte ChipSelect { get; set; }
  
        /// <summary>
        /// 地址
        /// </summary>
        public uint Address { get; set; }

        /// <summary>
        /// 读取长度
        /// </summary>
        public uint Length { get; set; }

        /// <summary>
        /// 地址上的数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public AddressCommandParameter()
        { }

        /// <summary>
        /// 读地址操作，初始化属性
        /// </summary>
        /// <param name="chipSelect">片选码</param>
        /// <param name="address">地址</param>
        /// <param name="length">读取长度</param>
        public AddressCommandParameter(byte chipSelect, uint address, uint length)
        {
            ChipSelect = chipSelect;
            Address = address;
            Length = length;
        }

        /// <summary>
        /// 读地址操作，初始化属性
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">读取长度</param>
        public AddressCommandParameter(uint address, uint length)
        {
            Address = address;
            Length = length;
        }

        /// <summary>
        /// 读地址操作，初始化属性
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">读取长度</param>
        /// <param name="data">期望的读出来的数据</param>
        public AddressCommandParameter(uint address, uint length, string data) 
        {
            Address = address;
            Length = length;
            Data = data;
        }

        /// <summary>
        /// 写地址操作，初始化属性
        /// </summary>
        /// <param name="chipSelect">片选码</param>
        /// <param name="address">地址</param>
        /// <param name="data">写入数据</param>
        public AddressCommandParameter(byte chipSelect, uint address, string data)
        {
            ChipSelect = chipSelect;
            Address = address;
            Data = data;
        }

        /// <summary>
        /// 写地址操作，初始化属性
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="data">写入数据</param>
        public AddressCommandParameter(uint address, string data)
        {
            Address = address;
            Data = data;
        }

        /// <summary>
        /// 擦除地址数据操作
        /// </summary>
        /// <param name="address">地址</param>
        public AddressCommandParameter(uint address)
        {
            Address = address;
        }

        /// <summary>
        /// 覆盖ToString，输出属性值
        /// </summary>
        /// <returns>key=value形式字符串</returns>
        public override string ToString()
        {
            return string.Format("ChipSelect = 0x{0:X2}, Address = 0x{1:X8}, Length = {2}, Data = {3}", ChipSelect, Address, Length, Data);
        }
    }
}
