using NumberSystems;

namespace NumberSystems
{

    static class Program
    {
        private static void Main()
        {
            Console.WriteLine("1 TASK\n");

            ToAll(287);
            ToAll(220);
            ToAll(332.1875f);
            ToAll(625.625f);
            ToAll(315.21f);

            Console.WriteLine("2 TASK\n");

            Console.WriteLine("a) 10101000 -> "+ Binary.ToDecimal(10101000));
            Console.WriteLine("b) 1101100 -> " + Binary.ToDecimal(1101100));
            Console.WriteLine("v) 10000010000.01001 -> " + Binary.ToDecimal(10000010000.01001));
            Console.WriteLine("g) 1110010100.001 -> " + Binary.ToDecimal(1110010100.001));
            Console.WriteLine("d) 1714.2 -> " + Octal.ToDecimal(1714.2f));
            Console.WriteLine("e) DD.3 -> " + Hex.ToDecimalFloat("DD.3"));


            Console.WriteLine("\n3 TASK\n");
            Console.WriteLine("a) 1100110 + 1011000110 -> " + Binary.Sum(1100110, 1011000110));
            Console.WriteLine("b) 100110 + 1001101111 -> " + Binary.Sum(100110, 1001101111));
            Console.WriteLine("v) 101001100.101 + 1001001100.01 -> " + Binary.Sum(101001100.101, 1001001100.01));
            Console.WriteLine("g) 275.2 + 724.2 -> " + Octal.Sum(275.2,724.2));
            Console.WriteLine("d) 165.6 + 3E.B -> " + Hex.SumFloat("165.6","3E.B"));


            Console.WriteLine("\n4 TASK\n");
            Console.WriteLine("a) 11011 - 1101 -> " + Binary.SubstractL(11011, 1101));
            Console.WriteLine("b) 1110001110 -100001011 -> " + Binary.SubstractL(1110001110, 100001011));
            Console.WriteLine("v) 110010100.01 - 1001110.1011 -> " + Binary.Substract(110010100.01, 1001110.1011));
            Console.WriteLine("g) 1330.2 - 1112.2 -> " + Octal.Substract(1330.2, 1112.2));
            Console.WriteLine("g) 3E.2 - AB.2 -> " + Hex.Substract("3E.2","AB.2"));

            Console.WriteLine("\n5 TASK\n");
            Console.WriteLine("a) 110000 * 1101100 -> " + Binary.Multiply(110000, 1101100));
            Console.WriteLine("b) 1560.2 * 101.2 -> " + Octal.Multiply(1560.2, 101.2));
            Console.WriteLine("b) 6.3 * 53.A -> " + Hex.Multiply("6.3", "53.A"));

        }

        private static void ToAll(int n)
        {
            Console.WriteLine(n +" ->");
            Console.WriteLine("\tB: " + Decimal.ToBinary(n));
            Console.WriteLine("\tO: " + Decimal.ToOctal(n));
            Console.WriteLine("\tH: " + Decimal.ToHex(n));
        }

        private static void ToAll(float n)
        {
            Console.WriteLine(n + " ->");
            Console.WriteLine("\tB: " + Decimal.ToBinary(n));
            Console.WriteLine("\tO: " + Decimal.ToOctal(n));
            Console.WriteLine("\tH: " + Decimal.ToHex(n));
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

        /// <summary>
        /// Return only float part
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="floatA"></param>
        /// <param name="floatB"></param>
        public static void FloatPart(double a, double b, ref long floatA, ref long floatB)
        {
            // only float part
            if (a.ToString().Contains("."))
            {
                floatA = long.Parse(a.ToString().Split(".").Last());
            }
            if (b.ToString().Contains("."))
            {
                floatB = long.Parse(b.ToString().Split(".").Last());
            }

            int longestNumber;
            if (floatA.ToString().Length > floatB.ToString().Length)
            {
                longestNumber = floatA.ToString().Length;
            }
            else
            {
                longestNumber = floatB.ToString().Length;
            }
            // make same length

            int aLength = floatA.ToString().Length;
            while (floatA.ToString().Length < longestNumber - aLength)
            {
                if (floatA.ToString().First() == '0') break;
                floatA = long.Parse(floatA.ToString() + "0");
            }

            int bLength = floatB.ToString().Length;
            while (floatB.ToString().Length < longestNumber - bLength)
            {
                if (floatB.ToString().First() == '0') break;
                floatB = long.Parse(floatB.ToString() + "0");
            }
        }

        public static void FloatPart(string a, string b, ref string smallA, ref string smallB)
        {
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
        }
    }
}