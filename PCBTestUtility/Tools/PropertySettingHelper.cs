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

using Microstar.Production.PCBTest;
using System.Windows.Forms;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// 类属性设置帮助类，由于枚举命名有要求，不能与ComboBox里面Items直接对应
    /// </summary>
    public static class PropertySettingHelper
    {
        /// <summary>
        /// 字符串转为相应的枚举类型，用于设置MeterType get函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ConnectionType MeterTypeStringToEnum(string str)
        {
            if (str == "Single Phase")
            {
                return ConnectionType.SinglePhase;
            }
            else if (str == "2 Phase 3 Wire")
            {
                return ConnectionType.TwoPhaseThreeWire;
            }
            else if (str == "3 Phase 3 Wire")
            {
                return ConnectionType.ThreePhaseThreeWire;
            }
            else
            {
                return ConnectionType.ThreePhaseFourWire;
            }
        }

        /// <summary>
        /// 枚举转为相应的字符串 用于设置MeterType set函数
        /// </summary>
        /// <param name="electricMeterType"></param>
        /// <returns></returns>
        public static string MeterTypeEnumToString(ConnectionType electricMeterType)
        {
            if (electricMeterType == ConnectionType.SinglePhase)
            {
                return "Single Phase";
            }
            else if (electricMeterType == ConnectionType.TwoPhaseThreeWire)
            {
                return "2 Phase 3 Wire";
            }
            else if (electricMeterType == ConnectionType.ThreePhaseThreeWire)
            {
                return "3 Phase 3 Wire";
            }
            else
            {
                return "3 Phase 4 Wire";
            }
        }

        /// <summary>
        /// 字符串转为相应的枚举类型，用于设置Protocal get函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static MeterProtocol ProtocalStringToEnum(string str)
        {
            if (str == "DLT-645")
            {
                return MeterProtocol.DLT645;
            }
            else if (str == "IEC 62056-21")
            {
                return MeterProtocol.IEC62056_21;
            }
            else
            {
                return MeterProtocol.DLMS;
            }
        }

        /// <summary>
        ///  枚举转为相应的字符串，用于设置Protocal set函数
        /// </summary>
        /// <param name="meterProtocal"></param>
        /// <returns></returns>
        public static string ProtocalEnumToString(MeterProtocol meterProtocal)
        {
            if (meterProtocal == MeterProtocol.DLT645)
            {
                return "DLT-645";
            }
            else if (meterProtocal == MeterProtocol.IEC62056_21)
            {
                return "IEC 62056-21";
            }
            else
            {
                return "DLMS";
            }
        }
    }
}
