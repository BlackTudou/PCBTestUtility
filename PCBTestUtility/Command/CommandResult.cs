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
    /// 记录命令执行的结果
    /// </summary>
    public sealed class CommandResult
    {
        /// <summary>
        /// 记录通过/失败
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 记录测试对应的数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 记录额外的信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public CommandResult()
        { }

        /// <summary>
        /// 初始化Success属性
        /// </summary>
        /// <param name="success">通过/失败</param>
        public CommandResult(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// 初始化属性
        /// </summary>
        /// <param name="success">记录通过/失败</param>
        /// <param name="data">记录测试对应的数据</param>
        public CommandResult(bool success, string data)
        {
            Success = success;
            Data = data;
        }

        /// <summary>
        /// 初始化属性
        /// </summary>
        /// <param name="success">记录通过/失败</param>
        /// <param name="data">记录测试对应的数据</param>
        /// <param name="message">记录额外的信息</param>
        public CommandResult(bool success, string data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        /// <summary>
        /// 覆盖ToString为检测结果字符串
        /// </summary>
        /// <returns>检测结果字符串</returns>
        public override string ToString()
        {
            return string.Format("Success = {0}, Data = {1}, Message = {2}", Success.ToString(), Data, Message);
        }
    }
}
