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

namespace Microstar.Utility
{
    /// <summary>
    /// The extension class for the random class.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// The default start time for random date time.
        /// </summary>
        public static readonly DateTime DefaultStartTime = new DateTime(2000, 1, 1);

        /// <summary>
        /// The default end time for random date time.
        /// </summary>
        public static readonly DateTime DefaultEndTime = new DateTime(2099, 12, 31);

        /// <summary>
        /// Returns a random byte array of the specified length in bytes.
        /// </summary>
        /// <param name="rand">The random instance.</param>
        /// <param name="length">The length of the array.</param>
        /// <returns>The created random array.</returns>
        public static byte[] NextBytes(this Random rand, int length)
        {
            var result = new byte[length];
            rand.NextBytes(result);
            return result;
        }

        /// <summary>
        /// Returns a random date time in this century.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>The random date time.</returns>
        public static DateTime NextDateTime(this Random random)
        {
            return NextDateTime(random, DefaultStartTime, DefaultEndTime);
        }

        /// <summary>
        /// Returns a random date time before the specified end (inclusive) time.
        /// </summary>
        /// <param name="random">The random instance.</param>
        /// <param name="end">The end time.</param>
        /// <returns>The random date time.</returns>
        public static DateTime NextDateTime(this Random random, DateTime end)
        {
            return NextDateTime(random, DefaultStartTime, end);
        }

        /// <summary>
        /// Returns a random date time between the specified start and end (inclusive) time.
        /// </summary>
        /// <param name="random">The random instance.</param>
        /// <param name="start">The start time.</param>
        /// <param name="end">The end time.</param>
        /// <returns>The random date time.</returns>
        /// <exception cref="System.ArgumentException">End cannot be before start.</exception>
        public static DateTime NextDateTime(this Random random, DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentException("End cannot be before start.");  
            }

            var timespan = end - start;
            var seconds = (long)(random.NextDouble() * timespan.TotalSeconds);
            return start + TimeSpan.FromSeconds(seconds);
        }
    }
}
