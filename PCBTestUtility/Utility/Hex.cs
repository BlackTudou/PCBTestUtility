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
using System.Text;
using System.Text.RegularExpressions;

namespace Microstar.Utility
{
    /// <summary>
    /// Provides utility for the hex decimal string to byte conversion.
    /// </summary>
    public static class Hex
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString(byte[] bytes, int startIndex, int length)
        {
            byte[] data = new byte[length];
            Array.Copy(bytes, startIndex, data, 0, length);

            return ToString(data);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString(byte[] bytes)
        {
            return ToString(bytes, string.Empty);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString(byte[] bytes, string separator)
        {
            if (bytes == null)
            {
                return null;
            }

            if (bytes.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:X2}{1}", b, separator);
            return hex.ToString();
        }

        /// <summary>
        /// Froms the string.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns></returns>
        public static byte[] FromString(string hexString)
        {
            if (hexString == null)
            {
                return null;
            }

            if (hexString.Length == 0)
            {
                return new byte[0];
            }

            hexString = hexString.Trim().Replace(" ", "");

            int NumberChars = hexString.Length / 2;
            byte[] bytes = new byte[NumberChars];
            using (var sr = new StringReader(hexString))
            {
                for (int i = 0; i < NumberChars; i++)
                    bytes[i] =
                      Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
            }
            return bytes;
        }

        /// <summary>
        /// Determines whether is hexadecimal string.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>True if is hex decimal string, false otherwise.</returns>
        public static bool IsHexString(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                return false;
            }
            var target = hexString.Replace(" ", "");
            return Regex.IsMatch(target, @"\A\b[0-9a-fA-F]+\b\Z") 
                || Regex.IsMatch(target, @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z");

        }
    }
}
