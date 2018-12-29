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
    /// 继电器控制命令参数
    /// </summary>
    public class RelayControlCommandParameter : CommandParameter
    {
        private string selectedNumber;
        /// <summary>
        /// 继电器动作
        /// </summary>
        public RelayControlAction Action { get; set; }

        /// <summary>
        /// 受控继电器序号，受控继电器序号范围是0-21，序号之间用逗号隔开。为方便组帧，序号可写为ALL，这时继电器动作只能是CLOSE
        /// </summary>
        public string SelectedNumber
        {
            get { return selectedNumber; }
            set { this.selectedNumber = value.ToUpper(); }
        }
        
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public RelayControlCommandParameter()
        { }

        /// <summary>
        /// 初始化受控继电器序号，继电器动作
        /// </summary>
        /// <param name="selectedNumber"></param>
        /// <param name="action"></param>
        public RelayControlCommandParameter(RelayControlAction action, string selectedNumber)
        {
            SelectedNumber = selectedNumber;
            Action = action;
        }

        /// <summary>
        /// 覆盖ToString()为OBIS参数形式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Action = {0}, SelectedNumber = {1}", Action.ToString(), SelectedNumber);
        }        
    }
}
