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
using System.Runtime.Serialization;
using System.Security;

namespace Microstar.Production.Comms
{
    /// <summary>
    /// 通信异常类
    /// </summary>
    public class CommunicationException : Exception
    {
        /// <summary>
        /// 初始化 CommunicationException 类的新实例。
        /// </summary>
        public CommunicationException()
        { }

        /// <summary>
        ///  用指定的错误消息初始化 CommunicationException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        public CommunicationException(string message) 
            : base(message)
        { }

        /// <summary>
        /// 使用指定的错误消息和对作为此异常原因的内部异常的引用来初始化 CommunicationException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        /// <param name="innerException">导致当前异常的异常。 如果 innerException 参数不是 null 引用，则在处理内部异常的 catch 块中引发当前异常。</param>
        public CommunicationException(string message, Exception innerException) 
            : base(message, innerException)
        { }

        /// <summary>
        /// 用序列化数据初始化 CommunicationException 类的新实例。
        /// </summary>
        /// <param name="info">承载序列化对象数据的对象。</param>
        /// <param name="context">关于来源和目标的上下文信息</param>
        [SecuritySafeCritical]
        protected CommunicationException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        { }   
    }  
}
