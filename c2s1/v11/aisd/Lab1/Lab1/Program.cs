using System;
static class Program
{
    private static void Main()
    {
        string input = Console.ReadLine();

        long m = long.Parse(input.Split(' ')[1]) % 100000000;
        long n = long.Parse(input.Split(' ')[0]) % 100000000;

        long r = 0;
        long i = 0;
        long k = 1;
        while (i < n)
        {
            long tmp = r % m;
            r += k;
            k = tmp;
            i++;
        }

        Console.WriteLine(r % m);
    }

}