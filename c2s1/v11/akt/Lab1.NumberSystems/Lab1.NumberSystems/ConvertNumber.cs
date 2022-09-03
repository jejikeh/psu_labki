using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystems
{
    internal static class ConvertDecimal
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
        internal static float ToBinary(float number)
        {
            return float.Parse(ConvertFloat(number, 2));
        }

        /// <summary>
        /// Decinmal int to octal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static int ToOctal(int number)
        {
            return int.Parse(ConvertInt(number, 2));
        }

        /// <summary>
        /// Decinmal float to octal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static float ToOctal(float number)
        {
            return float.Parse(ConvertFloat(number, 8));
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
            while (number > 0)
            {
                if (foot == 16)
                {
                    float rem = number % foot;
                    if (rem >= 10)
                    {
                        // cs
                        res += (Hex)rem;
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

            return StringHelper.ReverseString(res);
        }


        private static string ConvertFloat(float number, int foot)
        {
            if (number < 1)
            {
                return  "0." + ConvertSmallFloat(number, foot);
            }
            else
            {
                string intPartResult = ConvertInt((int)number, foot);
                string floatPartResult = ConvertSmallFloat(number - (int)number, foot);
                return intPartResult + "." + floatPartResult;
            }
        }

        /// <summary>
        /// For numbers less than one
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        private static string ConvertSmallFloat(float number, int foot)
        {
            string res = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                number *= foot;
                res += number < 10 ? (int)number : (Hex)number;
                number -= (int)number;
            }

            return res;
        }
    }

    internal static class ConvertBinary
    {
        /// <summary>
        /// Octal int to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static int ToDecimal(int number)
        {
            float res = 0;
            var numberString = number.ToString();
            for (int i = 0; i < numberString.Length; i++)
            {
                res += int.Parse(numberString[i].ToString()) * MathF.Pow(2, (numberString.Length - 1) - i);
            }
            return (int)res;
        }

        /// <summary>
        /// Octal float to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static float ToDecimal(float number)
        {
            if(number < 1)
            {
                return ConvertSmallFloatToDecimal(number);
            }
            else
            {
                int intPartResult = ToDecimal((int)number);
                float floatPartResult = ConvertSmallFloatToDecimal(number - (int)number);
                return intPartResult + floatPartResult;
            }
        }

        private static float ConvertSmallFloatToDecimal(float number)
        {
            float res = 0;
            string numberString = number.ToString().Replace("0.","");
            for (int i = -1; i > -3; i--)
            {
                res += float.Parse(numberString[-i-1].ToString()) * MathF.Pow(2,i);
            }

            return res;
        }
    }

    internal static class ConvertOctal
    {
        /// <summary>
        /// Octal int to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static int ToDecimal(int number)
        {
            float res = 0;
            var numberString = number.ToString();
            for (int i = 0; i < numberString.Length; i++)
            {
                res += int.Parse(numberString[i].ToString()) * MathF.Pow(8, (numberString.Length - 1) - i);
            }
            return (int)res;
        }

        /// <summary>
        /// Octal float to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static float ToDecimal(float number)
        {
            if (number < 1)
            {
                return ConvertSmallFloatToDecimal(number);
            }
            else
            {
                int intPartResult = ToDecimal((int)number);
                float floatPartResult = ConvertSmallFloatToDecimal(number - (int)number);
                return intPartResult + floatPartResult;
            }
        }

        private static float ConvertSmallFloatToDecimal(float number)
        {
            if (number == 0) return 0f;
            float res = 0;
            string numberString = number.ToString().Replace("0.", "");
            for (int i = -1; i > -3; i--)
            {
                res += float.Parse(numberString[-i - 1].ToString()) * MathF.Pow(8, i);
            }

            return res;
        }
    }

    internal static class ConvertHex
    {
        /// <summary>
        /// Hex or Octal int to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static int ToDecimal(int number)
        {
            float res = 0;
            var numberString = number.ToString();
            for (int i = 0; i < numberString.Length; i++)
            {
                res += int.Parse(numberString[i].ToString()) * MathF.Pow(16, (numberString.Length - 1) - i);
            }
            return (int)res;
        }
    }
    internal static class StringHelper
    {
        public static string ReverseString(string str)
        {
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }

    internal enum Hex
    {
        A = 10,
        B = 11,
        C = 12,
        D = 13,
        E = 14,
        F = 15
    }
}
