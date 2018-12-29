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

using System.IO;
using System.Xml.Serialization;
using System;

namespace Microstar.Utility
{
    /// <summary>
    /// XML文件序列化 反序列化
    /// </summary>
    public static class SerializeHelper
    {
        /// <summary>
        /// 序列化为XML文档
        /// </summary>
        /// <param name="instance">TestProject实例</param>
        /// <param name="pathName">文件路径名</param>
        public static void SerializeXML<T>(T instance, string pathName)
        {
            if (string.IsNullOrWhiteSpace(pathName))
            {
                throw new ArgumentException("Path name can't be null or empty.");
            }
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                
                using (TextWriter txtWriter = new StreamWriter(pathName))
                {
                    xml.Serialize(txtWriter, instance);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Serialize failed:{0}", ex.Message));
            }
        }

        /// <summary>
        /// 将XML文档反序列化为对象实例
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static T DeserializeXML<T>(string pathName)
        {
            if (!File.Exists(pathName))
            {
                throw new ArgumentException(string.Format("File {0} not found.", pathName));
            }

            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StreamReader(pathName))
            {
                return (T)xml.Deserialize(textReader);
            }
        }
    }
}
