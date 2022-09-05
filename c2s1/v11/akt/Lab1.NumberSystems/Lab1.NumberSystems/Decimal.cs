using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystems
{
    internal static class Decimal
    {
        /// <summary>
        /// Decimal int to binary
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static int ToBinary(int number)
        {
            return int.Parse(ConvertInt(number, 2));
        }


        /// <summary>
        /// Decimal float to binary
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static double ToBinary(double number)
        {
            return double.Parse(ConvertFloat(number, 2));
        }

        /// <summary>
        /// Decinmal int to octal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static int ToOctal(int number)
        {
            return int.Parse(ConvertInt(number, 9));
        }

        /// <summary>
        /// Decinmal float to octal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static double ToOctal(double number)
        {
            return double.Parse(ConvertFloat(number, 8));
        }


        /// <summary>
        /// Decimal int to hex
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static string ToHex(int number)
        {
            return ConvertInt(number, 16);
        }

        /// <summary>
        /// Decimal float to hex
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static string ToHex(float number)
        {
            return ConvertFloat(number, 16);
        }


        /// <summary>
        /// Convert decimal int to some number system
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        private static string ConvertInt(int number, int foot)
        {
            string res = string.Empty;
            bool isNegative = number < 0;
            if (isNegative)
            {
                number = -number;
            }
            while (number > 0)
            {
                if (foot == 16)
                {
                    float rem = number % foot;
                    if (rem >= 10)
                    {
                        // cs
                        res += (HexNumber)rem;
                    }
                    else
                    {
                        res += rem;
                    }
                }
                else
                {
                    res += number % foot;
                }
                number /= foot;
            }

            if (isNegative)
            {
                return "-" + StringHelper.ReverseString(res);
            }else
            {
                return StringHelper.ReverseString(res);
            }
        }


        private static string ConvertFloat(double number, int foot)
        {
            bool isNegative = number < 0;
            if (isNegative)
            {
                number = -number;
            }

            if (number < 1 && number > 0)
            {
                if (isNegative)
                {
                    return "-0." + ConvertSmallFloat(number, foot);
                }
                else
                {
                    return  "0." + ConvertSmallFloat(number, foot);
                }
            }
            else
            {
                string intPartResult = ConvertInt((int)number, foot);
                string floatPartResult = ConvertSmallFloat(number - (int)number, foot);
                if (isNegative)
                {
                    return "-"+ intPartResult + "." + floatPartResult;
                }
                else
                {
                    return intPartResult + "." + floatPartResult;
                }
            }
        }

        /// <summary>
        /// For numbers less than one
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        private static string ConvertSmallFloat(double number, int foot)
        {
            string res = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                number *= foot;
                res += number < 10 ? (int)number : (HexNumber)number;
                number -= (int)number;
            }

            return res;
        }
    }
}
