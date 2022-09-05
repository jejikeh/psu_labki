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
        internal static double ToDecimal(double number)
        {
            if (number < 1)
            {
                return ConvertSmallFloatToDecimal(number);
            }
            else
            {
                int intPartResult = ToDecimal((int)number);
                double floatPartResult = ConvertSmallFloatToDecimal(number - (int)number);
                return intPartResult + floatPartResult;
            }
        }

        private static double ConvertSmallFloatToDecimal(double number)
        {
            if (number == 0) return 0f;
            double res = 0;
            string numberString = number.ToString().Replace("0.", "");
            for (int i = -1; i > -3; i--)
            {
                res += double.Parse(numberString[-i - 1].ToString()) * Math.Pow(8, i);
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


            StringHelper.FloatPart(a,b,ref smallA, ref smallB);


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

        internal static long Substract(long a, long b)
        {
            long res = 0;
            
            while(Sum(b, res) != a)
            {
                res = Sum(res, 1);
            }

            return res;
        }

        internal static double Substract(double a, double b)
        {
            var ad = Octal.ToDecimal(a);
            var ab = Octal.ToDecimal(b);

            return Decimal.ToOctal(ad - ab);
        }

        internal static double Multiply(double a, double b)
        {
            var ad = Octal.ToDecimal(a);
            var ab = Octal.ToDecimal(b);

            return Decimal.ToOctal(ad * ab);
        }
    }
}
