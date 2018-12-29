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
    /// 错误信息
    /// </summary>
    public struct WriteError
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode;

        /// <summary>
        /// 额外的信息，比如这是做什么操作等
        /// </summary>
        public string Message;

        /// <summary>
        /// 覆盖ToString为类似"(ERR001) 错误详细信息"这种格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("(ERR{0}) {1}", ErrorCode.ToString("d3"), ErrorCodeInterpreter.Interpret(ErrorCode));
        }
    }
}
