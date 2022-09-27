using NumberSystems;

namespace NumberSystems
{

    static class Program
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("1 TASK\n");

            ToAll(945);
            ToAll(444.125f);

            Console.WriteLine("2 TASK\n");

            Console.WriteLine("a) 110001111 -> "+ Binary.ToDecimal(110001111));
            Console.WriteLine("v) 100110101.1001 -> " + Binary.ToDecimal(100110101.1001));


            Console.WriteLine("\n3 TASK\n");
            Console.WriteLine("a) 1000011101 + 101000010 -> " + Binary.Sum(1000011101, 101000010));
            Console.WriteLine("v) 101111011.01 + 1000100.101 -> " + Binary.Sum(101001100.101, 10001001100.01));


            Console.WriteLine("\n4 TASK\n");
            Console.WriteLine("a) 1000101110 - 1111111 -> " + Binary.SubstractL(1011111111, 100000011));
            Console.WriteLine("v) 1000101001.1 - 1111101.1 -> " + Binary.Substract(1000101001.1, 1111101.1));

            Console.WriteLine("\n5 TASK\n");
            Console.WriteLine("a) 111010 * 1100000 -> " + Binary.Multiply(111010, 1100000));
            Console.WriteLine("v) 4A.3 * F.5 -> " + Hex.Multiply("4A.3", "F.5"));

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