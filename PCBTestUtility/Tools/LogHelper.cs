using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// log4net帮助类
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// 打印提示
        /// </summary>
        /// <param name="txt"></param>
        public static void Info(string txt)
        {
            ILog log = log4net.LogManager.GetLogger("loginfo");
            log.Info(txt);
        }

        /// <summary>
        /// 打印提示
        /// </summary>
        /// <param name="txt"></param>
        public static void Info(string txt, Type type)
        {
            ILog log = log4net.LogManager.GetLogger(type);
            log.Info(txt);
        }

        /// <summary>
        /// 打印错误
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            ILog log = log4net.LogManager.GetLogger("logerror");
            log.Error(msg);
        }
        /// <summary>
        /// 打印错误
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg, Exception ex)
        {
            ILog log = log4net.LogManager.GetLogger("logerror");
            log.Error(msg, ex);
        }

        /// <summary>
        /// 将字节数组转成字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:X2} ", b);
            }

            return sb.ToString();
        }
    }
}
