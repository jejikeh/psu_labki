using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystems
{
    internal static class Binary
    {
        // Convert

        /// <summary>
        /// Octal int to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static long ToDecimal(long number)
        {
            float res = 0;
            bool isNegative = false;
            var numberString = number.ToString();
            if (numberString[0] == '-')
            {
                isNegative = true;
                numberString = numberString.Remove(0, 1);
            }
            for (int i = 0; i < numberString.Length; i++)
            {
                res += long.Parse(numberString[i].ToString()) * MathF.Pow(2, (numberString.Length - 1) - i);
            }
            if (isNegative)
            {
                return -(long)res;

            }else
            {
                return (long)res;
            }
        }

        /// <summary>
        /// Octal float to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static double ToDecimal(double number)
        {
            bool isNegative = number < 0;
            if (isNegative)
            {
                number = -number;
            }
            if (number < 1 && number > 0)
            {
                return ConvertSmallFloatToDecimal(number.ToString().Split(".").Last());
            }
            else
            {
                long intPartResult = ToDecimal((long)number);
                double floatPartResult = 0;
                if (number.ToString().Contains("."))
                {
                    floatPartResult = ConvertSmallFloatToDecimal(number.ToString().Split(".").Last());
                }
                if (isNegative)
                {
                    return -(intPartResult + floatPartResult);
                }
                else
                {
                    return intPartResult + floatPartResult;
                }
            }
        }
        private static float ConvertSmallFloatToDecimal(float number)
        {
            float res = 0;
            if (number == 0) return 0;
            string numberString = number.ToString();
            for (int i = 0; i < numberString.Length; i++)
            {
                res += float.Parse(numberString[i].ToString()) * MathF.Pow(2, i);
            }

            return res/10;
        }

        private static double ConvertSmallFloatToDecimal(string numberString)
        {
            double res = 0;
            if (numberString == "0") return 0;
            for (int i = 0; i < numberString.Length; i++)
            {
                res += double.Parse(numberString[i].ToString()) * Math.Pow(2, -i - 1);
            }

            return res;
        }


        // Calculate

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
                res = (a % 10 + b % 10 + rem) % 2 + res;
                rem = (int)((a % 10 + b % 10 + rem) / 2);
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
        internal static long SubstractL(long a, long b, int rem = 0)
        {
            string res = string.Empty;
            long ra = a;
            long rb = b;


            while (a != 0 || b != 0)
            {
                if ((a % 10 - b % 10 - rem) % 2 < 0)
                {
                    res = Math.Abs(((a % 10 - b % 10 - rem) % 2)) + res;
                    //rem = -1;
                }
                else
                {
                    res = ((a % 10 - b % 10 - rem) % 2) + res;
                    //rem = 0;
                }
                rem = (int)((a % 10 - b % 10 - rem)) > 0 ? 0 : (int)((a % 10 - b % 10 - rem));
                a /= 10; b /= 10;
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
                smallRes = (smallA % 10 + smallB % 10 + rem) % 2 + smallRes;
                rem = (int)((smallA % 10 + smallB % 10 + rem) / 2);
                smallA /= 10; smallB /= 10;
            }

            long al = (long)a;
            long bl = (long)b;
            while (al != 0 || bl != 0)
            {
                res = (al % 10 + bl % 10 + rem) % 2 + res;
                rem = (int)((al % 10 + bl % 10 + rem) / 2);
                al /= 10; bl /= 10;
            }

            if (rem != 0)
            {
                res = rem + res;
            }

            return res + "." + smallRes;
        }

        

        /// <summary>
        /// Substract of binary double
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static double Substract(double a, double b)
        {
            double ad = Binary.ToDecimal(a);
            double bd = Binary.ToDecimal(b);

            return Decimal.ToBinary(ad - bd);
        }

        /// <summary>
        /// Multiply of binary double
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static double Multiply(double a, double b)
        {
            double ad = Binary.ToDecimal(a);
            double bd = Binary.ToDecimal(b);

            return Decimal.ToBinary(ad * bd);
        }
    }
}
