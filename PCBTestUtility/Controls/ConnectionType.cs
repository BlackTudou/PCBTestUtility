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
namespace Microstar.Production.PCBTest
{
    /// <summary>
    /// 电表类型
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// 单相表
        /// </summary>
        SinglePhase = 0,

        /// <summary>
        /// 两相三线
        /// </summary>
        TwoPhaseThreeWire = 1,

        /// <summary>
        /// 三相三线
        /// </summary>
        ThreePhaseThreeWire = 2,

        /// <summary>
        /// 三相四线
        /// </summary>
        ThreePhaseFourWire = 3
    }
}
