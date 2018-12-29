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
using System.Text;
using System.Text.RegularExpressions;

namespace Microstar.Utility
{
    /// <summary>
    /// Utility class for bit-wise operations.
    /// </summary>
    public static class Bits
    {
        /// <summary>
        /// The bit string regex.
        /// </summary>
        private static readonly Regex BitStringRegex = new Regex(@"[01]+");
        
        /// <summary>
        /// Determines whether bit of the specified index is set in the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The index of the bit string (highest bit of first byte as 0).</param>
        /// <returns>
        /// True if the bit is set; False otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="IndexOutOfRangeException">The specified index exceeds the range of the bytes.</exception>
        public static bool IsBitSet(byte[] bytes, int index)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            if (index < 0 || index >= bytes.Length * 8)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "The specified index {0} exceeds the range of the bytes ({1}).", 
                        index, 
                        bytes.Length * 8));
            }

            return IsBitSetInternal(bytes, index);
        }

        /// <summary>
        /// Sets the bit of the byte array at the specified index.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The index of the bit string (highest bit of first byte as 0).</param>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="IndexOutOfRangeException">The specified index exceeds the range of the bytes.</exception>
        public static void SetBit(byte[] bytes, int index)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            if (index < 0 || index >= bytes.Length * 8)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "The specified index {0} exceeds the range of the bytes ({1}).",
                        index,
                        bytes.Length * 8));
            }

            SetBitInternal(bytes, index, true);
        }

        /// <summary>
        /// Clears the bit at the specified index of the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The index of the bit string (highest bit of first byte as 0).</param>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="IndexOutOfRangeException">The specified index exceeds the range of the bytes.</exception>
        public static void ClearBit(byte[] bytes, int index)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            if (index < 0 || index >= bytes.Length * 8)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "The specified index {0} exceeds the range of the bytes ({1}).",
                        index,
                        bytes.Length * 8));
            }

            SetBitInternal(bytes, index, false);
        }

        /// <summary>
        /// Converts the specified byte array to the corresponding bit string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The bit string, i.e. 01010101...</returns>
        public static string ToBitString(byte[] bytes)
        {
            if (bytes == null)
            {
                return string.Empty;
            }

            var result = new StringBuilder();

            for (int index = 0; index < bytes.Length * 8; index++)
            {
                if (IsBitSetInternal(bytes, index))
                {
                    result.Append('1');
                }
                else
                {
                    result.Append('0');
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts the specified bit string into byte array.
        /// </summary>
        /// <param name="bitString">The bit string.</param>
        /// <returns>The byte array.</returns>
        /// <exception cref="ArgumentNullException">bitString</exception>
        /// <exception cref="ArgumentException">
        /// The bit string must be a multiple of 8.
        /// or
        /// The specified string is not a bit string.
        /// </exception>
        public static byte[] FromBitString(string bitString)
        {
            if (string.IsNullOrWhiteSpace(bitString))
            {
                throw new ArgumentNullException("bitString");
            }

            if (bitString.Length % 8 != 0)
            {
                throw new ArgumentException("The bit string must be a multiple of 8.");
            }

            if (!BitStringRegex.IsMatch(bitString))
            {
                throw new ArgumentException("The specified string is not a bit string.");
            }

            var result = new byte[bitString.Length / 8];

            for (int index = 0; index < bitString.Length; index++)
            {
                if (bitString[index] == '1')
                {
                    SetBitInternal(result, index, true);
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified byte array has the bit set (internal without the checks).
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The index.</param>
        /// <returns>True if the bit is set; False otherwise.</returns>
        private static bool IsBitSetInternal(byte[] bytes, int index)
        {
            var byteIndex = index / 8;
            var byteOffset = index % 8;

            var mask = 0x80 >> byteOffset;

            return (bytes[byteIndex] & mask) == mask;
        }

        /// <summary>
        /// Sets the bit at the specified index of the specified byte array (internal without the checks).
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The index.</param>
        /// <param name="set">True if to set the bits; False if to clear the bits</param>
        private static void SetBitInternal(byte[] bytes, int index, bool set)
        {
            var byteIndex = index / 8;
            var byteOffset = index % 8;

            if (set)
            {
                bytes[byteIndex] |= (byte)(0x01 << byteOffset);
            }
            else
            {
                bytes[byteIndex] &= (byte)~(0x01 << byteOffset);
            }
        }
    }
}
