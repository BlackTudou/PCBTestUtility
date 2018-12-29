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

using Microstar.Production.PCBTest.Command;
using System.Drawing;

namespace Microstar.Production.PCBTest.Controls
{
    /// <summary>
    /// 参数control接口
    /// </summary>
    public interface IParameterControl
    {
        /// <summary>
        /// control ID
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 误差范围标题，标记是什么误差
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// 获取或设置该控件的左上角相对于其容器的左上角的坐标
        /// </summary>
        Point Location { get; set; }

        /// <summary>
        /// 保存参数
        /// </summary>
        CommandParameter Parameter { get; set; }

        //void Show();
    }
}
