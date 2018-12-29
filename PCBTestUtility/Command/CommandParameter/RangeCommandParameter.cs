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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 误差参数
    /// </summary>
    [Serializable]
    public class RangeCommandParameter : CommandParameter
    {
        /// <summary>
        /// 误差下限
        /// </summary>
        public decimal LowerLimit { get; set; }

        /// <summary>
        /// 误差上限
        /// </summary>
        public decimal UpperLimit { get; set; }

        /// <summary>
        /// 无参构造
        /// </summary>
        public RangeCommandParameter()
        { }

        /// <summary>
        /// 初始化属性
        /// </summary>
        /// <param name="lowerLimit">误差下限</param>
        /// <param name="upperLimit">误差上限</param>
        public RangeCommandParameter(decimal lowerLimit, decimal upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        /// <summary>
        /// 判断测量值是否在误差范围内
        /// </summary>
        /// <param name="measureValue">测量值</param>
        /// <returns>true: 在范围内，false: 不在范围内</returns>
        public bool IsWithinRange(decimal measureValue)
        {
            if (measureValue < LowerLimit || measureValue > UpperLimit)
            {
                return false;
            }
            return true;
        }
    }
}
