namespace Lab2.MachineCodes;

public static class Converter
{
    internal static long DecimalToBinary(long num)
    {
        string res = String.Empty;
        while (num > 0)
        {
            // add to the end of the string
            res = (num % 2) + res;
            num /= 2;
        }
        return long.Parse(res);
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

    internal static string DecimalToBCD(float num)
    {
        string res = String.Empty;
        string numStr = num.ToString();
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
    
    internal static double BSDtoDecimal(string num)
    {
        string res = String.Empty;
        string[] numStr = num.ToString().Split(' ');

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

        return double.Parse(res);
    }

    internal static string TextToAscii(string input)
    {
        string res = String.Empty;
        foreach (int c in input.Where(x => x < 127))
        {
            res += c + " ";
        }

        return res;
    }
    
    internal static string AsciiToText(string input)
    {
        string res = String.Empty;
        foreach (string c in input.Split(' '))
        {
            if(c != String.Empty)
                res += (char)int.Parse(c);
        }
        return res;
    }

    internal static string StraightCode(long number)
    {
        if (number < 0)
        {
            return  "1" + DecimalToBinary(number * -1).ToString();
        }
        
        return  "0" + DecimalToBinary(number).ToString();
    }

    internal static string ReversedCode(long number, int a = 0)
    {
        
        if (number > 0)
            return StraightCode(number);
        
        var res = StraightCode(number);
        if (a == 8)
        {
            while (res[1..].Length - 1 < 8)
            {
                res = "1" + ""
            }
        }
        res = res[1..].Replace('0', '2')
            .Replace('1', '0')
            .Replace('2', '1');

        return "1" + res;
    }
    
    internal static string AdditionalCode(long number)
    {
        if (number > 0)
            return Converter.StraightCode(number);
        
        return Calculator.Sum(long.Parse(Converter.ReversedCode(number)), 1).ToString();
    }

    internal static string Normalize(decimal number)
    {
        int l = 0;
        if (Math.Abs(number) < 1)
        {
            int exp = 0;
            while (Math.Abs(number) * 10 < 1)
            {
                number *= 10;
                exp++;
            }

            while (number.ToString().Reverse().First() == '0')
            {
                number = decimal.Parse(number.ToString().Substring(0,number.ToString().Length - 1));
            }
            return number.ToString() + $" * 10^(-{exp})";
        }
        else
        {
            int exp = 0;
            while (Math.Abs(number) > 1)
            {
                number /= 10;
                exp++;
            }
            
            while (number.ToString().Reverse().First() == '0')
            {
                number = decimal.Parse(number.ToString().Substring(0,number.ToString().Length - 1));
            }
            return number.ToString() + $" * 10^({exp})";
        }
    }

    internal static double DeNormalize(string normalizedNumber)
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

        return double.Parse(numberString) * Math.Pow(10, int.Parse(powString));
    }
}