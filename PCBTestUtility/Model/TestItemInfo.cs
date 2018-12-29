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
using Microstar.Production.PCBTest.Command;
using System.Xml.Serialization;

namespace Microstar.Production.PCBTest.Model
{
    /// <summary>
    /// 检测项信息,用于序列化
    /// </summary>
    [Serializable]
    public sealed class TestItemInfo
    {
        /// <summary>
        /// 检测项ID
        /// </summary>
        [XmlAttribute]
        public int ID { get; set; }

        /// <summary>
        /// 检测项名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 检测类型
        /// </summary>
        [XmlAttribute]
        public TestTargetType TestTargetType { get; set; }

        /// <summary>
        /// 参数实例
        /// </summary>
        public CommandParameter Parameter { get; set; }   
    }
}
