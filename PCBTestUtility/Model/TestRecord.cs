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

namespace Microstar.Production.PCBTest.Model
{
    /// <summary>
    /// 检测信息，与数据库中的相匹配
    /// </summary>
    public sealed class TestRecord
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 表号
        /// </summary>
        public string MeterNumber { get; set; }

        /// <summary>
        /// 检测员工号
        /// </summary>
        public int InspectorNumber { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 开检时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 检测项目
        /// </summary>
        public string Items { get; set; }

        /// <summary>
        /// 检测结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 细节信息
        /// </summary>
        public string DetailedInformation { get; set; }
    }
}
