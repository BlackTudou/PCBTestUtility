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
    /// 直流电流测量命令类
    /// </summary>
    public sealed class MeasureDCCurrentCommand : MeasureCommandBase
    {
        /// <summary>
        /// 测量命令名字
        /// </summary>
        public override string Name
        {
            get { return Resources.Command_MeasureDCCurrent; }
        }

        /// <summary>
        /// 开始测量OBIS
        /// </summary>
        public override string Obis
        {
            get { return "0-0:199.128.4"; }
        }

        /// <summary>
        /// 读测量结果OBIS
        /// </summary>
        public override string ReadResultObis
        {
            get { return "0-0:199.128.4"; }
        }

        /// <summary>
        /// 测量结果单位
        /// </summary>
        public override string Unit
        {
            get { return "uA"; }
        }

        /// <summary>
        ///  直流电流测量命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public override bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            if (!base.CanExecute(parameter, context))
            {
                return false;
            }

            var para = parameter as MeasureParameter;

            //直流电流测量引脚，引脚号取值为1（测量引脚VABT1）和2(测量引脚VBAT2)。
            if (para.PinNumber < 1 || para.PinNumber > 2)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">电量测量命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        protected override string FormatWriteParameter(MeasureParameter parameter)
        {
            return string.Format("{0},{1}", parameter.CurrentRange.ToString().Substring(0, 1), parameter.PinNumber);
        }
    }
}
