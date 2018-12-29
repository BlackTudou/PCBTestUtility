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

using Microstar.Production.PCBTest.Command;
using System;
using System.Xml.Serialization;


namespace Microstar.Production.PCBTest.Model
{
    /// <summary>
    /// 命令描述，用于序列化
    /// </summary>
    [Serializable]
    public sealed class CommandDescription
    {
        /// <summary>
        /// 命令名字
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 检测项目类型
        /// </summary>
        [XmlAttribute]
        public TestTargetType TestTargetType { get; set; }

        /// <summary>
        /// 资源文件ID
        /// </summary>
        [XmlElement]
        public string ResoureId { get; set; }

        /// <summary>
        /// 所用的命令类型
        /// </summary>
        [XmlElement]
        public string CommandType { get; set; }

        /// <summary>
        /// 误差控件类型
        /// </summary>
        [XmlElement]
        public string ErrorControlType { get; set; }

        /// <summary>
        /// 检测项的参数
        /// </summary>
        [XmlElement]
        public CommandParameter CommandParameter { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CommandDescription()
        { }
    }
}
