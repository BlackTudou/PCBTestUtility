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
using System;
using System.Collections.Generic;
using System.Resources;

namespace Microstar.Production.Comms.PCB
{
    /// <summary>
    /// 错误码转换为详细错误信息
    /// </summary>
    public static class ErrorCodeInterpreter
    {
        /// <summary>
        /// 存储ErrCode的Dictionary
        /// </summary>
        private static Lazy<Dictionary<int, string>> errorDictionary = new Lazy<Dictionary<int, string>>(() => new Dictionary<int, string>());
 
        /// <summary>
        /// 错误码转换为详细错误信息
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <returns>详细错误信息</returns>
        public static string Interpret(int errorCode)
        {
            InitializeDictionary();

            if (!errorDictionary.Value.ContainsKey(errorCode))
            {
                return string.Format("Unknown Error(Error Code:{0})", errorCode);
            }

            ResourceManager manager = new ResourceManager("Microstar.Production.PCBTest.Properties.Resources", typeof(Resources).Assembly);

            return manager.GetString(errorDictionary.Value[errorCode]);      
        }

        /// <summary>
        /// 往Dictionary里面添加ErrCode
        /// </summary>
        private static void InitializeDictionary()
        {
            if (!errorDictionary.IsValueCreated)
            {
                errorDictionary.Value.Add(1, "ERR001");
                errorDictionary.Value.Add(3, "ERR003");
                errorDictionary.Value.Add(4, "ERR004");
                errorDictionary.Value.Add(5, "ERR005");

                for (int i = 600; i <= 622; i++)
                {
                    errorDictionary.Value.Add(i, "ERR" + i.ToString());
                }             
            }
        }
    }
}
