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

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 保存传递给命令的参数
    /// </summary>
    [XmlInclude(typeof(RangeCommandParameter))]
    [XmlInclude(typeof(MeasureParameter))]
    [XmlInclude(typeof(AddressCommandParameter))]
    [XmlInclude(typeof(ForceProgramCommandParameter))]
    [XmlInclude(typeof(MeterCommunicationCommandParameter))]
    [XmlInclude(typeof(RelayControlCommandParameter))]
    [XmlInclude(typeof(SecondSignalCalibrationParameter))]
    public class CommandParameter
    {
        private Dictionary<string, string> commandParameter = new Dictionary<string, string>();

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public CommandParameter()
        { }

        /// <summary>
        /// 声明索引器
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string this[string key]
        {
            get
            {
                if (!commandParameter.ContainsKey(key))
                {
                    return string.Empty;
                }
                return commandParameter[key];
            }
            set
            {
                if (!commandParameter.ContainsKey(key))
                {
                    commandParameter.Add(key, value);
                }
                else
                {
                    this.commandParameter[key] = value;
                }
            }
        }
    }
}
