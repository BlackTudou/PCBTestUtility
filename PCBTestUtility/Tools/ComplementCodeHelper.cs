using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// 计算补码帮助类
    /// </summary>
    public static class ComplementCodeHelper
    {
        private const char POSITIVE_SIGN = '0';
        private const char SECONT_CHAR_B = '1';
        private const char FIRST_CHAR_B = '0';

        /// <summary>
        /// 计算补码
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static decimal CalcComplementCode(decimal val)
        {
            var temp = Math.Round(val / 3m * 10m, MidpointRounding.AwayFromZero);
            string str = temp.ToString();
            int a = Convert.ToInt32(str);
            if (a >= 5)
            {
                temp = Math.Round(temp / 10m, MidpointRounding.AwayFromZero);
            }
            else
            {
                temp = Math.Round(temp / 10m, MidpointRounding.AwayFromZero);
            }

            if (temp > 0)
            {
                return temp * (-1m);
            }
            else
            {
                return temp * (-1m);
            }
        }


        /// <summary>
        /// 计算补码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ClacComplementCode(string dataF)
        {
            if (dataF[0] == POSITIVE_SIGN)
            {
                return dataF;
            }

            StringBuilder result = new StringBuilder();

            bool carry = dataF.Last() == SECONT_CHAR_B;
            result.Append(carry ? FIRST_CHAR_B : SECONT_CHAR_B);

            for (int i = dataF.Length - 2; i >= 0; i--)
            {
                if (carry)
                {
                    carry = dataF[i] == SECONT_CHAR_B;
                    result.Insert(0, carry ? FIRST_CHAR_B : SECONT_CHAR_B);

                    continue;
                }

                result.Insert(0, dataF[i]);
            }

            return result.ToString();
        }
    }
}
