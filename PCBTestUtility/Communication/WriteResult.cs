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

namespace Microstar.Production.Comms.PCB
{
    /// <summary>
    /// WriteCommand返回结果
    /// </summary>
    public class WriteResult
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
        /// 默认构造函数
        /// </summary>
        public WriteResult()
        { }

        /// <summary>
        /// 初始化Success
        /// </summary>
        /// <param name="success">是否正确回复</param>
        public WriteResult(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// 初始化Success,Error
        /// </summary>
        /// <param name="success">是否正确回复</param>
        /// <param name="error">错误信息</param>
        public WriteResult(bool success, WriteError error)
        {
            Success = success;
            Error = error;
        }
    }
}
