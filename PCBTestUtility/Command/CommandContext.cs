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
using System;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 保存一些不同命令之间可能需要通信的参数，或者一些检测参数，比如表号等
    /// </summary>
    public sealed class CommandContext
    {
        private Dictionary<string, string> contextParameter = new Dictionary<string, string>();

        public static readonly string SerialNumberKey = "SerialNumber";

        /// <summary>
        /// 声明索引器
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string this[string key]
        {
            get
            {
                if (!contextParameter.ContainsKey(key))
                {
                    return string.Empty;
                }
                return contextParameter[key];
            }
            set
            {
                if (!contextParameter.ContainsKey(key))
                {
                    contextParameter.Add(key, value);
                }
                else
                {
                    this.contextParameter[key] = value;
                }               
            }
        }

        /// <summary>
        /// 记录板子的编号
        /// </summary>
        public string SerialNumber
        {
            get { return this[SerialNumberKey]; }
            set { this[SerialNumberKey] = value; }
        }
    }
}
