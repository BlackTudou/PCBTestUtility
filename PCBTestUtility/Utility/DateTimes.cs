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
using System.Globalization;
using System.Text.RegularExpressions;

namespace Microstar.Utility
{
    /// <summary>
    /// Helper class for the date time parsing.
    /// </summary>
    public static class DateTimes
    {
        /// <summary>
        /// The invariant culture.
        /// </summary>
        private static readonly Lazy<CultureInfo> invariantCulture = new Lazy<CultureInfo>(() =>
        {
            var cal = (Calendar)CultureInfo.InvariantCulture.Calendar.Clone();
            cal.TwoDigitYearMax = 2099;
            var cultureInfo = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            cultureInfo.DateTimeFormat.Calendar = cal;
            return cultureInfo;
        });
        
        /// <summary>
        /// The regular expression for not available date time.
        /// </summary>
        private static readonly Regex NotAvailableDateTimeRegex = new Regex(@"(0|1)?(00|FF)\W(00|FF)\W(00|FF)\s(00|FF)\W(00|FF)(\W(00|FF))?");
        
        /// <summary>
        /// The not available date time.
        /// </summary>
        public static readonly DateTime NotAvailableDateTime = new DateTime(1900, 1, 1);

        /// <summary>
        /// Gets the invariant culture for date time parsing.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public static CultureInfo InvariantCulture
        {
            get
            {
                return invariantCulture.Value;
            }
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its System.DateTime 
        /// equivalent using the specified format. The format of the string representation must 
        /// match the specified format exactly. The method returns a value that indicates whether 
        /// the conversion succeeded.
        /// </summary>
        /// <param name="dateTimeString">The date time string.</param>
        /// <param name="format">The format.</param>
        /// <param name="result">The result.</param>
        /// <returns>True if the conversion succeeded; False otherwise.</returns>
        public static bool TryParseExact(string dateTimeString, string format, out DateTime result)
        {
            if (NotAvailableDateTimeRegex.IsMatch(dateTimeString))
            {
                result = NotAvailableDateTime;
                return true;
            }
            
            if (format.StartsWith("z"))
            {
                // Special handling for the DST symbol.
                dateTimeString = dateTimeString.Substring(1, dateTimeString.Length - 1);
                format = format.Substring(1, format.Length - 1);
            }

            return DateTime.TryParseExact(dateTimeString, format, InvariantCulture, DateTimeStyles.None, out result);
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its System.DateTime 
        /// equivalent using the specified format. The format of the string representation must 
        /// match the specified format exactly.
        /// </summary>
        /// <param name="dateTimeString">The date time string.</param>
        /// <param name="format">The format.</param>
        /// <returns>The date time value.</returns>
        public static DateTime ParseExact(string dateTimeString, string format)
        {
            if (NotAvailableDateTimeRegex.IsMatch(dateTimeString))
            {
                return NotAvailableDateTime;
            }

            if (format.StartsWith("z"))
            {
                // Special handling for the DST symbol.
                dateTimeString = dateTimeString.Substring(1, dateTimeString.Length - 1);
                format = format.Substring(1, format.Length - 1);
            }

            return DateTime.ParseExact(dateTimeString, format, InvariantCulture, DateTimeStyles.None);
        }


        /// <summary>
        /// Converts the date time to string with specified format (support start with Z for IEC DST).
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents the specified date time.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">format</exception>
        public static string ToString(DateTime dateTime, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException("format");
            }

            var prefix = string.Empty;
            if (format.StartsWith("z"))
            {
                format = format.Substring(1, format.Length - 1);
                prefix = dateTime.IsDaylightSavingTime() ? "1" : "0";
            }

            return prefix + dateTime.ToString(format);
        }
    }
}
