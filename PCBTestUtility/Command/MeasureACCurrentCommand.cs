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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 交流电流测量命令
    /// </summary>
    public sealed class MeasureACCurrentCommand : MeasureCommandBase
    {
        /// <summary>
        /// 测量命令名字
        /// </summary>
        public override string Name
        {
            get { return Resources.Command_MeasureACCurrent; }
        }

        /// <summary>
        /// 开始测量OBIS
        /// </summary>
        public override string Obis
        {
            get { return "0-0:199.128.5"; }
        }

        /// <summary>
        /// 读测量结果OBIS
        /// </summary>
        public override string ReadResultObis
        {
            get { return "0-0:199.128.5*1"; }
        }

        /// <summary>
        /// 测量结果单位
        /// </summary>
        public override string Unit
        {
            get { return "mA"; }
        }

        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">电量测量命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        protected override string FormatWriteParameter(MeasureParameter parameter)
        {
            return parameter.Phase.ToString();
        }
    }
}
