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

namespace Microstar.Production.PCBTest
{
    /// <summary>
    /// 电流规格
    /// </summary>
    public sealed class CurrentRating
    {
        /// <summary>
        /// 基准电流
        /// </summary>
        public decimal Ib { get; set; }

        /// <summary>
        /// 最大电流
        /// </summary>
        public decimal Imax { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CurrentRating()
        { }

        /// <summary>
        /// 初始化IB Imax
        /// </summary>
        /// <param name="iB"></param>
        /// <param name="iMax"></param>
        public CurrentRating(decimal iB, decimal iMax)
        {
            Ib = iB;
            Imax = iMax;
        }

        /// <summary>
        /// 覆盖ToString为类似0.3(1.2)电流格式，方便放在ComboBox里
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}({1})", Ib, Imax);
        }

        /// <summary>
        /// 从ComboBox选项里的字符串"0.3(1.2)"中获取Ib Imax
        /// </summary>
        /// <param name="displayName">显示在ComboxBox里的电流字符串值</param>
        public void Update(string displayName)
        {
            int leftBracketIndex = displayName.IndexOf('(');
            int rightBracketIndex = displayName.IndexOf(')');

            if (leftBracketIndex == -1 || rightBracketIndex == -1)
            {
                return;
            }

            Ib = Convert.ToDecimal(displayName.Substring(0, leftBracketIndex));
            Imax = Convert.ToDecimal(displayName.Substring(leftBracketIndex + 1, rightBracketIndex - leftBracketIndex - 1));
        }  
    }
}
