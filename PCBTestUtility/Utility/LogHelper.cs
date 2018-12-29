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

using System;
using System.IO;

namespace Microstar.Utility
{
    /// <summary>
    /// Helper class for the log4net logger.
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// The initialized.
        /// </summary>
        private static bool initialized = false;

        /// <summary>
        /// Initializes the log4net logger with the specified configuration file path.
        /// </summary>
        /// <param name="configFilePath">The configuration file path.</param>
        public static void Initialize(string configFilePath)
        {
            if (initialized)
            {
                return;
            }
            
            try
            {
                var logConfigFile = new FileInfo(configFilePath ?? "log4net.config");
                log4net.Config.XmlConfigurator.Configure(logConfigFile);
                initialized = true;
            }
            catch
            {
                Console.WriteLine("Warning: Failed to load logging config file. No logging will be recorded.");
                // Do nothing.
            }
        }
    }
}
