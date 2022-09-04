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
            Console.WriteLine("g) 1100110 + 1011000110 -> " + Octal.Sum(275.2,724.2));
            Console.WriteLine("d) 165.6 + 3E.B -> " + Hex.SumFloat("165.6","3E.B"));
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
    }
}