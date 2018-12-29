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

using Microstar.Production.Comms.PCB;
using Microstar.Production.Comms;
using Microstar.Production.PCBTest.Properties;
using Microstar.Production.Tools;
using System;

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 强制编程命令，将检测板上SPI Flash内bin文件写入表上I2C EEPROM
    /// </summary>
    public sealed class ForceProgramCommand : ICommand
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ForceProgramCommand));
        
        /// <summary>
        /// 测量命令名字
        /// </summary>
        public string Name
        {
            get { return Resources.Command_ForceProgram; }
        }

        /// <summary>
        /// 检测命令OBIS码
        /// </summary>
        public string Obis
        {
            get { return "0-0:199.128.6"; }
        }

        /// <summary>
        /// 强制编程命令在其当前状态下是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>命令是否可执行</returns>
        public bool CanExecute(CommandParameter parameter, CommandContext context)
        {    
            var programParameter = parameter as ForceProgramCommandParameter;
            if (programParameter == null)
            {
                return false;
            }

            if (programParameter.I2CAddress < 0x0000 || programParameter.I2CAddress > 0xFFFF)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 执行强制编程命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="parameter">命令参数</param>
        /// <param name="context">不同命令之间的通信参数</param>
        /// <returns>检测结果</returns>
        public CommandResult Execute(PcbTesterClient client, CommandParameter parameter, CommandContext context)
        {
            var forceProgramParameter = parameter as ForceProgramCommandParameter;

            WriteResult writeResult = client.Write(Obis, FormatWriteParameter(forceProgramParameter));

            if (!writeResult.Success)
            {
                string message = string.Format(
                    Resources.ForceProgramCommand_WriteFailedMessageFormat,
                    this.Name,
                    writeResult.Error.ToString(),
                    forceProgramParameter.ToString());

                logger.Error(message);
                throw new CommunicationException(message);
            }

            //读取强编状态
            ReadResult readResult = client.Read(Obis, string.Empty);

            while (StringResultToEnum(readResult.Data) == ForceProgramState.ForceProgramProcessing)
            {
                System.Threading.Thread.Sleep(1000);
                readResult = client.Read(Obis, string.Empty);

                if (!readResult.Success) 
                {
                    break;
                }

                if (readResult.Data == ForceProgramState.Succeed.ToString())
                {
                    break;
                }
            }
            //强编失败
            if (!readResult.Success)
            {
                return new CommandResult(
                    false,
                    readResult.Error.ToString(),
                    string.Format(
                        Resources.ForceProgramCommand_ForceProgramErrorMessageFormat,
                        this.Name,
                        forceProgramParameter.ToString(),
                        ForceProgramState.Succeed.ToString(),
                        readResult.Error.ToString()));
            }

            return new CommandResult(true);
        }
     
        /// <summary>
        /// 转为字符串形式OBIS参数
        /// </summary>
        /// <param name="parameter">强编命令参数类实例</param>
        /// <returns>字符串形式OBIS参数</returns>
        private string FormatWriteParameter(ForceProgramCommandParameter parameter)
        {
            uint length = ForceProgramHelper.CalculateForceProgramLength(parameter.Length);
      
            uint spiAddress = ForceProgramHelper.CalculateSpiAddress(parameter.SpiAddress);
                
            return string.Format("0x{0:X2},0x{1:X4},0x{2:X8},0x{3:X8}", parameter.I2CChipSelect, parameter.I2CAddress, spiAddress, length);
        }

        /// <summary>
        /// 将字符串形式的检测结果转换为Enum ForceProgramState形式
        /// </summary>
        /// <param name="result">字符串形式检测结果</param>
        /// <returns>Enum形式</returns>
        private ForceProgramState StringResultToEnum(string result)
        {
            return (ForceProgramState)Enum.Parse(typeof(ForceProgramState), result.Replace(" ", ""));
        }
    }
}
