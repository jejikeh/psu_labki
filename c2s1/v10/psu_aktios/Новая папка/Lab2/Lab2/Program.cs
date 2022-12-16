using System.Formats.Asn1;

static class Program

{
     static string DecimalToBinary(string number)
    {  long num=Int64.Parse(number);
        string res = String.Empty;
        while (num > 0)
        {
            res = (num % 2) + res;
            num /= 2;
        }
        return res;
    }
    private static Dictionary<int, string> BsdTable = new()
    {
        {0,"0000"},
        {1,"0001"},
        {2,"0010"},
        {3,"0011"},
        {4,"0100"},
        {5,"0101"},
        {6,"0110"},
        {7,"0111"},
        {8,"1000"},
        {9,"1001"}
    };
    static string DecToBi(string number)
    {
        string res = String.Empty;
        string numStr = number;
        while (numStr.Length > 0)
        {
            if (numStr[0] == '.')
            {
                res += ". ";
                numStr = numStr[1..];
                continue;
            }
            res += BsdTable[int.Parse(numStr[0].ToString())] + " ";
            numStr = numStr[1..];
        }

        return res;
    }
    static string BCToDec(string number)
    {
        string res = String.Empty;
        string[] numStr = number.Split(' ');

        foreach (var code in numStr)
        {
            if (code == ".")
            {
                res += "."; continue;
            }
                
            foreach (var decode in BsdTable.Where(x => x.Value == code))
            {
                res += decode.Key;
            }
        }

        return res;
    }
    static string TextToA(string text)
    {
        string res = String.Empty;
        foreach (int c in text.Where(x => x < 127))
        {
            res += c + " ";
        }

        return res;
    }
    static string AToText(string text)
    {
        string res = String.Empty;
        foreach (string c in text.Split(' '))
        {
            if(c != String.Empty)
                res += (char)int.Parse(c);
        }
        return res;
    }
    static string StraightC(string number)
    {
        long num= Int64.Parse(number);
        if (num < 0)
        {
            number = (num * -1).ToString();
            return  "1" + DecimalToBinary(number).ToString();
        }
        
        return  "0" + DecimalToBinary(number).ToString();
    }

    static string ReversedCode(string number)
    {
        long num= Int64.Parse(number);
        if (num > 0)
            return StraightC(number);
        
        var res = StraightC(number);
        res = res[1..].Replace('0', '2')
            .Replace('1', '0')
            .Replace('2', '1');

        return "1" + res;
    }
    static string ReversedC(string number)
    {
        long num= Int64.Parse(number);
        if (num > 0)
            return StraightC(number);
        
        var res = StraightC(number);
        res = res[1..].Replace('0', '2')
            .Replace('1', '0')
            .Replace('2', '1');

        return "1" + res;
    }
   static string AdditionalC(string number)
    {
        long num= Int64.Parse(number);
        if (num > 0)
            return StraightC(number);
        
        return Sum(long.Parse(ReversedC(number)), 1).ToString();
    }
    static string Normalize(string number)
    {
        decimal num = Convert.ToDecimal(number);
        int l = 0;
        if (Math.Abs(num) < 1)
        {
            int exp = 0;
            while (Math.Abs(num) * 10 < 1)
            {
                num *= 10;
                exp++;
            }

            while (number.ToString().Reverse().First() == '0')
            {
                num = decimal.Parse(num.ToString().Substring(0,num.ToString().Length - 1));
            }
            return num.ToString() + $" * 10^(-{exp})";
        }
        else
        {
            int exp = 0;
            while (Math.Abs(num) > 1)
            {
                num /= 10;
                exp++;
            }
            
            while (num.ToString().Reverse().First() == '0')
            {
                num = decimal.Parse(num.ToString().Substring(0,num.ToString().Length - 1));
            }
            return num.ToString() + $" * 10^({exp})";
        }
    }

    static string DeNormalize(string normalizedNumber)
    {
        normalizedNumber = normalizedNumber.Replace(" ", "");
        
        var powString = string.Empty;
        while (normalizedNumber.Last() != '(')
        {
            if (normalizedNumber.Last() != ')')
            {
                powString = normalizedNumber.Last() + powString;
            }
            normalizedNumber = normalizedNumber[..^1];
        }

        var numberString = string.Empty;
        while (normalizedNumber.First() != '*')
        {
            numberString += normalizedNumber.First();
            normalizedNumber = normalizedNumber[1..];
        }

        return (double.Parse(numberString) * Math.Pow(10, int.Parse(powString))).ToString();
    }
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
        string a1 = a.ToString();
       string  b1 = b.ToString();
        // check minus
        var aStr = a > 0 ? StraightC(a1) : ReversedC(a1);
        var bStr = b > 0 ? StraightC(b1) : ReversedC(b1);

        long res = Sum(int.Parse(aStr), int.Parse(bStr));
        
        if (res.ToString().Length > 7)
        {
            res = long.Parse(res.ToString()[1..]);
            res = SubstractL(res, 1);
        }
        return res.ToString();
    }
    
     static string AdditionalSum(long a, long b)
    {
        string a1 = a.ToString();
        string  b1 = b.ToString();
        // check minus
        var aStr = a > 0 ? ReversedC(a1) : AdditionalC(a1);
        var bStr = b > 0 ? ReversedC(b1) : AdditionalC(b1);

        long res = Sum(int.Parse(aStr), int.Parse(bStr));

        if (res.ToString().Length > 7)
        {
            res = long.Parse(res.ToString()[1..]);
            res = SubstractL(res, 1);
        }
        return res.ToString();
    }

    internal static string NormilizeSum(string a, string b)
    {
        long a1 = Convert.ToInt64(a);
        long b1 = Convert.ToInt64(b);
        return Normalize((decimal)(DeNormalize(a1)) + (decimal)DeNormalize(b1));
    }
    
    internal static string NormilizeSubstract(string a, string b)
    {
        return Normalize((decimal)(DeNormalize(a)) - (decimal)DeNormalize(b));
    }
    
    internal static string NormilizeMutliply(string a, string b)
    {
        return Normalize((decimal)(DeNormalize(a)) * (decimal)DeNormalize(b));
    }
    
    internal static string NormilizeDevide(string a, string b)
    {
        return Normalize((decimal)(DeNormalize(a)) / (decimal)DeNormalize(b));
    }


    static int Main()
    {
        string number =Console.ReadLine();
        string text= Console.ReadLine();
        return 0;
    }
}