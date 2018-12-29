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
    /// 电量测量参数
    /// </summary>
    public sealed class MeasureParameter : RangeCommandParameter
    {
        /// <summary>
        /// 测量相线
        /// </summary>
        public Phase Phase { get; set; }

        /// <summary>
        /// 测量引脚
        /// </summary>
        public int PinNumber { get; set; }

        /// <summary>
        /// 直流电流测量量程，量程取值为“L”(Large)，“M”(Middle)，“S”(Small)。
        /// </summary>
        public CurrentRange CurrentRange { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public MeasureParameter()
        { }

        /// <summary>
        /// 初始化上下限
        /// </summary>
        /// <param name="lowerLimit">误差下限</param>
        /// <param name="upperLimit">误差上限</param>
        public MeasureParameter(decimal lowerLimit, decimal upperLimit) 
            : base(lowerLimit, upperLimit)
        { }

        /// <summary>
        /// 交流测量，初始化相线
        /// </summary>
        /// <param name="phase">相线</param>
        public MeasureParameter(Phase phase)
        {
            Phase = phase;
        }

        /// <summary>
        /// 直流电压测量，初始化引脚
        /// </summary>
        /// <param name="pinNumber">引脚号</param>
        public MeasureParameter(int pinNumber)
        {
            PinNumber = pinNumber;
        }

        /// <summary>
        /// 直流电流测量，初始化引脚和量程
        /// </summary>
        /// <param name="pinNumber">引脚号</param>
        /// <param name="range">量程</param>
        public MeasureParameter(int pinNumber, CurrentRange range)
        {
            PinNumber = pinNumber;
            CurrentRange = range;
        }

        /// <summary>
        /// 初始化引脚，上下限
        /// </summary>
        /// <param name="pinNumber">测量引脚</param>
        /// <param name="lowerLimit">下限</param>
        /// <param name="upperLimit">上限</param>
        public MeasureParameter(int pinNumber, decimal lowerLimit, decimal upperLimit)
        {
            PinNumber = pinNumber;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        /// <summary>
        /// 初始化引脚，量程，上下限
        /// </summary>
        /// <param name="pinNumber">测量引脚</param>
        /// <param name="range"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        public MeasureParameter(int pinNumber, CurrentRange range,decimal lowerLimit, decimal upperLimit)
        {
            PinNumber = pinNumber;
            CurrentRange = range;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        /// <summary>
        /// 初始化相线
        /// </summary>
        /// <param name="phase">相线</param>
        /// <param name="lowerLimit">下限</param>
        /// <param name="upperLimit">上限</param>
        public MeasureParameter(Phase phase, decimal lowerLimit, decimal upperLimit)
        {
            Phase = phase;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        /// <summary>
        /// 覆盖ToString，输出属性值
        /// </summary>
        /// <returns>key=value形式字符串</returns>
        public override string ToString()
        {
            return string.Format("PinNumber = {0}, CurrentRange = {1}, Phase = {2}, LowerLimit = {3}, UpperLimit = {4}",
                PinNumber, CurrentRange.ToString(), Phase.ToString(), LowerLimit, UpperLimit);
        } 
    }
}
