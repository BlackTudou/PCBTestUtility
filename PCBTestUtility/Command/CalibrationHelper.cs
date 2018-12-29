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

namespace Microstar.Production.PCBTest.Command
{
    /// <summary>
    /// 校正交流测量命令
    /// </summary>
    public static class CalibrationHelper
    {
        /// <summary>
        /// 校正电流测量命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="current">电流标准值，单位mA</param>
        /// <returns>命令结果</returns>
        public static WriteResult CalibrateCurrent(PcbTesterClient client, decimal current)
        {
            return client.Write("0-0:199.128.5*4", string.Format("{0}mA", current));
        }

        /// <summary>
        /// 校正电压测量命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="voltage">电压标准值，单位V</param>
        /// <returns>命令结果</returns>
        public static WriteResult CalibrateVoltage(PcbTesterClient client, decimal voltage)
        {
            return client.Write("0-0:199.128.5*5", string.Format("{0}V", voltage));
        }

        /// <summary>
        /// 校正相位命令
        /// </summary>
        /// <param name="client">PcbTesterClient句柄</param>
        /// <param name="phase">相位标准值</param>
        /// <returns>命令结果</returns>
        public static WriteResult CalibratePhase(PcbTesterClient client, int phase)
        {
            return client.Write("0-0:199.128.5*6", string.Format("0x{0:X2}", phase));
        }
    }
}
