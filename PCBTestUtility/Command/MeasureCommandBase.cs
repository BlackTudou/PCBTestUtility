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

using Microstar.Production.Comms;
using Microstar.Production.Comms.PCB;
using Microstar.Production.PCBTest.Properties;
using System;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 电量测量项目基类
    /// </summary>
    public abstract class MeasureCommandBase : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MeasureCommandBase));

        /// <summary>
        /// 测量命令名字
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 开始测量OBIS
        /// </summary>
        public abstract string Obis { get; }

        /// <summary>
        /// 读测量结果OBIS
        /// </summary>
        public abstract string ReadResultObis { get; }

        /// <summary>
        /// 测量电压电流值单位
        /// </summary>
        public abstract string Unit { get; }
     
        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">电量测量命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        protected abstract string FormatWriteParameter(MeasureParameter parameter);
            
        /// <summary>
        /// 测量命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public virtual bool CanExecute(CommandParameter parameter, CommandContext context)
        {
            var electricalParameter = parameter as MeasureParameter;
            if (electricalParameter == null)
            {
                return false;
            }
            return true;
        }
      
        /// <summary>
        /// 执行电量测量
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var electricalParameter = parameter as MeasureParameter;

            WriteResult writeResult = client.Write(Obis, FormatWriteParameter(electricalParameter));

            if (!writeResult.Success)
            {
                string message = string.Format(
                    Resources.MeasureCommandBase_StartFailedMessageFormat, 
                    this.Name, 
                    writeResult.Error.ToString(), 
                    electricalParameter.ToString());

                logger.Error(message);
                throw new CommunicationException(message);
            }

            ReadResult readResult = client.Read(ReadResultObis, string.Empty);

            //检测结果为错误码
            if (!readResult.Success)
            {
                string message = string.Format(
                    Resources.MeasureCommandBase_ReadResultFailedMessageFormat, 
                    this.Name, 
                    readResult.Error.ToString(), 
                    string.Empty);

                logger.Error(message);
                throw new CommunicationException(message);
            }

            decimal measureValue = ParseMeasureValue(readResult.Data, Unit);

            if (Unit == "mV") //单位mv
            {
                electricalParameter.LowerLimit *= 1000m;  //UI上设置的电压单位是V,直流电压测量的数据单位是mV，将V转为mV
                electricalParameter.UpperLimit *= 1000m;
            }

            //测量结果不在所规定的误差范围
            if (!electricalParameter.IsWithinRange(measureValue))
            {
                string expectedValue = string.Format("{0}{1}-{2}{3}", electricalParameter.LowerLimit, Unit, electricalParameter.UpperLimit, Unit);

                return new CommandResult(
                    false, 
                    readResult.Data, 
                    string.Format(
                        Resources.MeasureCommandBase_MeasureErrorMessageFormat,
                        this.Name, 
                        electricalParameter.PinNumber, 
                        electricalParameter.CurrentRange, 
                        electricalParameter.Phase, 
                        expectedValue, 
                        readResult.Data));
            }

            return new CommandResult(true, readResult.Data);
        }

        /// <summary>
        /// 对字符串形式测量结果进行转换，便于范围比较
        /// </summary>
        /// <param name="result">测量结果</param>
        /// <param name="unit">测量值单位</param>
        /// <returns>转换结果</returns>
        protected decimal ParseMeasureValue(string result, string unit)
        {
            if (result.IndexOf(unit) == -1)
            {
                throw new FormatException(string.Format(Resources.MeasureCommandBase_ParseFailedMessageFormat, result));
            }
            return Convert.ToDecimal(result.Substring(0, result.IndexOf(unit)));
        }
    }   
}
