using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystems
{
    internal static class Octal
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

        /// <summary>
        /// Sum of binary int
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static long Sum(long a, long b)
        {
            int rem = 0;
            string res = string.Empty;
            while (a != 0 || b != 0)
            {
                res = (a % 10 + b % 10 + rem) % 8 + res;
                rem = (int)((a % 10 + b % 10 + rem) / 8);
                a /= 10; b /= 10;
            }

            if (rem != 0)
            {
                res = rem + res;
            }

            return long.Parse(res);
        }

        /// <summary>
        /// Sum of binary int
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static string Sum(double a, double b)
        {
            int rem = 0;
            string res = string.Empty;
            string smallRes = string.Empty;
            long smallA = 0, smallB = 0;


            // only float part
            if (a.ToString().Contains("."))
            {
                smallA = long.Parse(a.ToString().Split(".").Last());
            }
            if (b.ToString().Contains("."))
            {
                smallB = long.Parse(b.ToString().Split(".").Last());
            }

            int longestNumber;
            if (smallA.ToString().Length > smallB.ToString().Length)
            {
                longestNumber = smallA.ToString().Length;
            }
            else
            {
                longestNumber = smallB.ToString().Length;
            }
            // make same length

            int aLength = smallA.ToString().Length;
            while (smallA.ToString().Length < longestNumber - aLength)
            {
                if (smallA.ToString().First() == '0') break;
                smallA = long.Parse(smallA.ToString() + "0");
            }

            int bLength = smallB.ToString().Length;
            while (smallB.ToString().Length < longestNumber - bLength)
            {
                if (smallB.ToString().First() == '0') break;
                smallB = long.Parse(smallB.ToString() + "0");
            }


            while (smallA != 0 || smallB != 0)
            {
                smallRes = (smallA % 10 + smallB % 10 + rem) % 8 + smallRes;
                rem = (int)((smallA % 10 + smallB % 10 + rem) / 8);
                smallA /= 10; smallB /= 10;
            }

            long al = (long)a;
            long bl = (long)b;
            while (al != 0 || bl != 0)
            {
                res = (al % 10 + bl % 10 + rem) % 8 + res;
                rem = (int)((al % 10 + bl % 10 + rem) / 8);
                al /= 10; bl /= 10;
            }

            if (rem != 0)
            {
                res = rem + res;
            }

            return res + "." + smallRes;
        }
    }
}
