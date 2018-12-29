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

using System.Collections.Generic;
using System;

namespace Microstar.Utility
{
    /// <summary>
    /// Utility class for array operations.
    /// </summary>
    public static class Arrays
    {
        /// <summary>
        /// Combines the array.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The combined array.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Array cannot be null.</exception>
        public static byte[] Combine(byte[] left, byte[] right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }

            var result = new List<byte>(left.Length + right.Length);
            result.AddRange(left);
            result.AddRange(right);
            return result.ToArray();
        }

        /// <summary>
        /// Checks if the two array contents are equal to one another.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>True if the two arrays are the same; False otherwise.</returns>
        public static bool AreEqual(byte[] left, byte[] right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (int index = 0; index < left.Length; index++)
            {
                if (left[index] != right[index])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
