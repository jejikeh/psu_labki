namespace Lab2.MachineCodes;

public class Calculator
{
    
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
    
    
    internal static long SubstractL(long a, long b)
    {
        string bStr = b.ToString();
        while (a.ToString().Length != bStr.Length)
            bStr = "0" + bStr;
        // reverse b
        bStr = bStr.Replace('0', '2')
            .Replace('1', '0')
            .Replace('2', '1');

        // add 1
        b = Sum(long.Parse(bStr), 1);
        return long.Parse(Sum(a, b).ToString()[1..]);
    }
    
    internal static string ReverseSum(long a, long b)
    {
        // check minus
        var aStr = a > 0 ? Converter.StraightCode(a) : Converter.ReversedCode(a);
        var bStr = b > 0 ? Converter.StraightCode(b) : Converter.ReversedCode(b);

        long res = Sum(int.Parse(aStr), int.Parse(bStr));
        
        if (res.ToString().Length > 7)
        {
            res = long.Parse(res.ToString()[1..]);
            res = SubstractL(res, 1);
        }
        return res.ToString();
    }
    
    internal static string AdditionalSum(long a, long b)
    {
        // check minus
        var aStr = a > 0 ? Converter.ReversedCode(a) : Converter.AdditionalCode(a);
        var bStr = b > 0 ? Converter.ReversedCode(b) : Converter.AdditionalCode(b);

        long res = Sum(int.Parse(aStr), int.Parse(bStr));

        if (res.ToString().Length > 7)
        {
            res = long.Parse(res.ToString()[1..]);
            res = SubstractL(res, 1);
        }
        return res.ToString();
    }

    internal static string NormalizeSum(string a, string b)
    {
        var aS = a.Split(" ");
    }
}