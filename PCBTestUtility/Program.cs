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
using Microstar.Production.View;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Microstar.Production.Tools;

namespace Microstar.Production.PCBTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;

            InitializeLogging();
            ApplyLocale();

            //显示登录窗口
            using (var dialog = new LoginDialog())
            {
                var result = dialog.ShowDialog();
                if (result != DialogResult.OK) 
                {
                    return;
                }
            }

            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBoxHelper.ShowError(e.Exception.Message);
        }

        /// <summary>
        /// 加载log4net配置文件
        /// </summary>
        static void InitializeLogging()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "log4net.config";
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(filePath));
        }

        /// <summary>
        /// 从配置文件读取Locale，然后设置到当前thread
        /// </summary>
        static void ApplyLocale()
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Settings.Default.Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
            }
            catch (CultureNotFoundException)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
        }
    }
}
