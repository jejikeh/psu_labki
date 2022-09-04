using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystems
{
    internal enum HexNumber
    {
        A = 10,
        B = 11,
        C = 12,
        D = 13,
        E = 14,
        F = 15
    }

    internal static class Hex
    {
        private static int HexNumberToDecimal(char s)
        {
            switch (s) {
                case 'A':
                    return (int)HexNumber.A;
                case 'B':
                    return (int)HexNumber.B;
                case 'C':
                    return (int)HexNumber.C;
                case 'D':
                    return (int)HexNumber.D;
                case 'E':
                    return (int)HexNumber.E;
                case 'F':
                    return (int)HexNumber.F;
                case '\0':
                    return 0;
            }

            return int.Parse(s.ToString());
        }

        /// <summary>
        /// Hex or Octal int to decimal
        /// </summary>
        /// <param name="number"></param>
        /// <param name="foot"></param>
        /// <returns></returns>
        internal static int ToDecimal(string numberString)
        {
            float res = 0;
            for (int i = 0; i < numberString.Length; i++)
            {
                var s = HexNumberToDecimal(numberString[i]);
                res += HexNumberToDecimal(numberString[i]) * MathF.Pow(16, (numberString.Length - 1) - i);
            }
            return (int)res;
        }

        internal static float ToDecimalFloat(string numberString)
        {
            int intPartResult = ToDecimal(numberString.Split(".").First());
            float floatPartResult = ConvertSmallFloatToDecimal(numberString.Split(".").Last());
            return intPartResult + floatPartResult;
        }

        private static float ConvertSmallFloatToDecimal(string numberString)
        {
            if (numberString == string.Empty) return 0f;
            float res = 0;
            for (int i = 0; i > -numberString.Length; i--)
            {
                res += HexNumberToDecimal(numberString[i]) * MathF.Pow(16, i - 1);
            }

            return res;
        }

        /// <summary>
        /// Sum of binary int
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static string Sum(string a, string b)
        {
            int rem = 0;
            string res = string.Empty;
            while (a.Length != 0 || b.Length != 0)
            {
                int an = HexNumberToDecimal(a.LastOrDefault());
                int bn = HexNumberToDecimal(b.LastOrDefault());
                res = ((an + bn + rem) % 16) >= 10 ? ((HexNumber)((an + bn + rem) % 16)) + res : ((an + bn + rem) % 16) + res;
                rem = ((an + bn + rem) / 16);

                if (a.Length - 1 < 0 || b.Length - 1 < 0)
                {
                    break;
                }
                a = a.Remove(a.Length - 1, 1);
                b = b.Remove(b.Length - 1, 1);
            }

            if (rem != 0)
            {
                res = rem + res;
            }

            return res;
        }

        /// <summary>
        /// Sum of binary int
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static string SumFloat(string a, string b)
        {
            int rem = 0;
            string res = string.Empty;
            string smallRes = string.Empty;
            string smallA = string.Empty, smallB = string.Empty;


            // only float part
            if (a.ToString().Contains("."))
            {
                smallA = a.ToString().Split(".").Last();
            }
            if (b.ToString().Contains("."))
            {
                smallB = b.ToString().Split(".").Last();
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
                smallA = smallA.ToString() + "0";
            }

            int bLength = smallB.ToString().Length;
            while (smallB.ToString().Length < longestNumber - bLength)
            {
                if (smallB.ToString().First() == '0') break;
                smallB = smallB.ToString() + "0";
            }


            while (smallA.Length != 0 || smallB.Length != 0)
            {
                int smallAN = HexNumberToDecimal(smallA.LastOrDefault());
                int smallBN = HexNumberToDecimal(smallB.LastOrDefault());
                smallRes = ((smallAN + smallBN + rem) % 16) >= 10 ? ((HexNumber)((smallAN + smallBN + rem) % 16)) + res : ((smallAN + smallBN + rem) % 16) + res;
                rem = ((smallAN + smallBN + rem) / 16);
                if (smallA.Length - 1 < 0 || smallB.Length - 1 < 0)
                {
                    break;
                }
                smallA = smallA.Remove(smallA.Length - 1, 1);
                smallB = smallB.Remove(smallB.Length - 1, 1);
            }

            string al = a.ToString().Split(".").First();
            string bl = b.ToString().Split(".").First();
            while (al.Length != 0 || bl.Length != 0)
            {
                int an = HexNumberToDecimal(al.LastOrDefault());
                int bn = HexNumberToDecimal(bl.LastOrDefault());
                res = ((an + bn + rem) % 16) >= 10 ? ((HexNumber)((an + bn + rem) % 16)) + res : ((an + bn + rem) % 16) + res;
                rem = ((an + bn + rem) / 16);

                if (al.Length - 1 < 0 || bl.Length - 1 < 0)
                {
                    break;
                }
                al = al.Remove(al.Length - 1, 1);
                bl = bl.Remove(bl.Length - 1, 1);
            }

            if (rem != 0)
            {
                res = rem + res;
            }

            return res + "." + smallRes;
        }
    }
}
