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

namespace Microstar.Production.Comms.PCB
{ 
    public class ReadResult
    {
        /// <summary>
        /// 是否正确回复
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public WriteError Error { get; set; }

        /// <summary>
        /// 检测结果数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 初始化ReadResult类的新实例
        /// </summary>
        public ReadResult()
        { }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        public ReadResult(bool success, WriteError error)
        {
            Success = success;
            Error = error;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="data"></param>
        public ReadResult(bool success, string data)
        {
            Success = success;
            Data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="data"></param>
        public ReadResult(bool success, WriteError error, string data)
        {
            Success = success;
            Error = error;
            Data = data;
        }
    }
}
