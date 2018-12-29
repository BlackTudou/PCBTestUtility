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
using System.Reflection;

namespace Microstar.Utility
{
    /// <summary>
    /// Utility class for the reflections.
    /// </summary>
    public static class Reflections
    {
        /// <summary>
        /// Creates the instance of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of the instance.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>The instance.</returns>
        /// <exception cref="System.InvalidOperationException">Type does not have default public constructor.</exception>
        public static T CreateInstance<T>(Type type)
        {
            var constructor = type.GetConstructor(new Type[] { });
            if (constructor == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Type {0} do not have default public constructor.",
                        type.FullName));
            }

            var result = constructor.Invoke(null);
            return (T)result;
        }

        /// <summary>
        /// Creates the instance using the default constructor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        /// The instance.
        /// </returns>
        public static T CreateInstance<T>()
        {
            return CreateInstance<T>(new Type[] {}, null);
        }
        
        /// <summary>
        /// Creates the instance with the specified types of parameters.
        /// </summary>
        /// <typeparam name="T">The type of instance.</typeparam>
        /// <param name="parameterTypes">The parameter types.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns>
        /// The created instance.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Untable to find the parameter types.</exception>
        public static T CreateInstance<T>(Type[] parameterTypes, object[] parameterValues)
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(parameterTypes);
            if (constructor == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Type {0} do not have public constructor with the specified types as argument.",
                        type.FullName));
            }

            var result = constructor.Invoke(parameterValues);
            return (T)result;

        }

        /// <summary>
        /// 根据类名创建实例
        /// </summary>
        /// <param name="typeName">类型名</param>
        /// <returns>创建的实例</returns>
        public static object CreateInstance(string typeName)
        {
            Type type = Type.GetType(typeName, false);
            if (type == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Can't find the type {0}",
                        typeName));
            }
            var constructor = type.GetConstructor(new Type[] { });
            if (constructor == null)
            {
                throw new InvalidOperationException(
                   string.Format(
                       "Type {0} do not have default public constructor.",
                       type.FullName));
            }
            return constructor.Invoke(null);
        }

        /// <summary>
        /// Gets the single attribute from the property.
        /// </summary>
        /// <typeparam name="T">The type of the attribute</typeparam>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns>
        /// The attribute instance.
        /// </returns>
        public static T GetSingleAttribute<T>(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(T), true);
            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }

            return default(T);
        }
    }
}
