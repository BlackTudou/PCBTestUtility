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

namespace Microstar.Production.PCBTest.Model
{
    /// <summary>
    /// 序列化model类
    /// </summary>
    [Serializable]
    public sealed class TestProject
    {
        /// <summary>
        /// 电压规格
        /// </summary>
        public decimal Voltage { get; set; } 

        /// <summary>
        /// 电流规格
        /// </summary>
        public CurrentRating Current { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 电表协议
        /// </summary>
        public MeterProtocol Protocol { get; set; }

        /// <summary>
        /// 电表类型
        /// </summary>
        public ConnectionType MeterType { get; set; }

        /// <summary>
        /// 当前检测的电表的0级密码
        /// </summary>
        public string MeterPassword { get; set; }

        /// <summary>
        /// 电表表号的位数
        /// </summary>
        public int MeterNumberDigits { get; set; }

        /// <summary>
        /// 是否允许电表表号输入'A'~'F'的HEX码
        /// </summary>
        public bool MeterNumberAllowAlphabetic { get; set; }

        /// <summary>
        /// 检测项目
        /// </summary>
        public List<TestItemInfo> SelectedTestItems { get; set; }
    }
}
