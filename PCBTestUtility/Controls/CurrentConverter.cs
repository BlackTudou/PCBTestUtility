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
using System.ComponentModel;

namespace Microstar.Production.PCBTest
{
    /// <summary>
    /// 自定义类型转化器
    /// </summary>
    public class CurrentConverter : TypeConverter
    {
        /// <summary>
        /// 表示是否允许将给定类型的对象转换为自定义类型
        /// </summary>
        /// <param name="context">当前上下文对象</param>
        /// <param name="sourceType">给定的类型</param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            //如果给定的类型为字符串，可以转换为自定义类型
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// 表示是否允许将自定义类型转换为指定的类型
        /// </summary>
        /// <param name="context">当前上下文</param>
        /// <param name="destinationType">指定的类型</param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            //如果目标类型是字符串，允许将自定义类型转换为字符串
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// 将指定类型转换为自定义类型
        /// </summary>
        /// <param name="context">当前上下文信息</param>
        /// <param name="culture">区域信息</param>
        /// <param name="value">指定类型</param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string current = (string)value;
                int leftBracketIndex = current.IndexOf('(');
                int rightBracketIndex = current.IndexOf(')');
                CurrentRating cu = new CurrentRating();
                cu.Ib = Convert.ToDecimal(current.Substring(0, leftBracketIndex));
                cu.Imax = Convert.ToDecimal(current.Substring(leftBracketIndex + 1, rightBracketIndex - leftBracketIndex - 1));
                return cu;
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// 将自定义类型转换为指定类型
        /// </summary>
        /// <param name="context">当前上下文信息</param>
        /// <param name="culture">区域信息</param>
        /// <param name="value">要转换的System.Object。</param>
        /// <param name="destinationType">指定类型</param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            //如果要转换为自定义类型
            if (destinationType == typeof(string))
            {
                if (value is CurrentRating)
                {
                    CurrentRating current = (CurrentRating)value;
                    return string.Format("{0}({1})", current.Ib, current.Imax);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// 返回此对象是否支持属性
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// 通过将指定的属性数组用作筛选器来为指定类型的组件返回属性的集合
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(CurrentRating), attributes);
        }
    }
}
