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
    /// 读I2C命令
    /// </summary>
    public sealed class ReadI2CCommand : ReadAddressCommandBase
    {
        /// <summary>
        /// 测量命令名字
        /// </summary>      
        public override string Name
        {
            get { return Resources.Command_ReadI2C; }
        }

        /// <summary>
        /// 检测命令OBIS码
        /// </summary>
        public override string Obis
        {
            get { return "0-0:199.128.7"; }
        }

        /// <summary>
        /// 读I2C命令在其当前状态下是否可执行
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

            var addressParameter = parameter as AddressCommandParameter;

            //I2C地址取值范围是0x0000-0xFFFF。
            if (addressParameter.Address < 0x0000 || addressParameter.Address > 0xFFFF)
            {
                return false;
            }

            if (addressParameter.Length < 0x00 || addressParameter.Length > 0x40)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">地址命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        protected override string FormatReadParameter(AddressCommandParameter parameter)
        {
            return string.Format("0x{0:X2},0x{1:X4},0x{2:X}", parameter.ChipSelect, parameter.Address, parameter.Length);
        }
    }
}
