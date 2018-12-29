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
using System.Windows.Forms;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// 消息框显示
    /// </summary>
    public static class MessageBoxHelper
    {
        /// <summary>
        ///错误消息框
        /// </summary>
        /// <param name="text">要在消息框中显示的文本。</param>
        public static void ShowError(string text)
        {
            MessageBox.Show(text, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 提示消息框
        /// </summary>
        /// <param name="text"></param>
        public static void ShowInfo(string text)
        {
            MessageBox.Show(text, Resources.Common_Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 警告消息框
        /// </summary>
        /// <param name="text"></param>
        public static void ShowWarning(string text)
        {
            MessageBox.Show(text, Resources.Common_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
