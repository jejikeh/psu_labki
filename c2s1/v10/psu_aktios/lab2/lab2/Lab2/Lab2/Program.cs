namespace Lab2;

static class Lab2
{
    static string BinToDec(string number)
    {
        int index = number.Length - 1;
            int res = 0;
            for (int i=0;i<=number.Length-1;i++)
            {
                res=res+(int.Parse(number[i].ToString())*Convert.ToInt32(Math.Pow(2, index)));
                index--;
            }
            number = string.Empty;
            number = Convert.ToString(res);
            return number;
    }
    static string DecToBin(long number)
    {  
        string result = String.Empty;
        while (number > 0)
        {
            result = (number % 2) + result;
            number /= 2;
        }
        return result;
    }

    static string DecimalToDb(string number)
    {
        string res = "";
        string resl = "";
        string resr = "";
        if (number.Contains('.'))
        {
            string[] num = number.Split('.');
            number = String.Empty;
            long k = 0;
            long left = Convert.ToInt64(num[0]);
            long right = Convert.ToInt64(num[1]);
            
                string mem = "";
                while (right != 0)
                {
                    k = right % 10;
                    right/= 10;
                    mem = DecToBin(k);
                    while (mem.Length != 4)
                    {
                        mem = '0' + mem;
                    }

                    resr =  mem + ' ' +resr ;
                }
                while (left != 0)
                {
                    k = left % 10;
                     left /= 10;
                    mem = DecToBin(k);
                    while (mem.Length != 4)
                    {
                        mem = '0' + mem;
                    }

                    resl =  mem + ' ' +resl ;
                }

                res = resl + '.' + resr;
                return res;
        }
        else
        {
            long k = 0;
            
                string mem = "";
                long num1 = Int64.Parse(number);
                k = 0;
                while (num1 != 0)
                {
                    k = num1 % 10;
                    num1 /= 10;
                    mem = DecToBin(k);
                    while (mem.Length != 4)
                    {
                        mem = '0' + mem;
                    }
                    res = mem + ' ' + res;
                }

                return res;
        }
    }

    static string DbToDecimal(string number)
    {
        if (number.Contains('.'))
        {
            string res = String.Empty;
            string resl = String.Empty;
            string resr = String.Empty;
            string[] num = number.Split('.');
            string[] numl = num[0].Split(' ');
            string[] numr = num[1].Split(' ');
            for (int i=0;i<numl.Length-1;i++)
            {
                resl += BinToDec(numl[i]);
            }
            for (int i=0;i<numr.Length;i++)
            {
                resr += BinToDec(numr[i]);
            }

            res = resl + "." + resr;
            return res;
        }
        else
        {
            string res = String.Empty;
            string[] num = number.Split(' ');
            for (int i=0;i<num.Length;i++)
            {
                res += BinToDec(num[i]);
            }
            return res;
        }
        
    }
    
    static string TextToAscii(string text)
    {
        string result = String.Empty;
        foreach (var i in text.Where(x => x < 127))
        {
            result += (int)i + " ";
        }

        return result;
    }
    
     static string AsciiToText(string code)
    {
        string result = String.Empty;
        foreach (string i in code.Split(' '))
        {
            if(i != String.Empty)
                result += (char)int.Parse(i);
        }
        return result;
    }
     static string StrC(string number)
     {
         long num = Int64.Parse(number);
         if (num < 0)
         {
             return  "1" + DecToBin(num * -1).ToString();
         }
        
         return  "0" + DecToBin(num).ToString();
     }
    static string RevC(string number)
     {long num = Int64.Parse(number);
         if (num > 0)
             return StrC(number);
        
         var res = StrC(number);
         res = res[1..].Replace('0', '2')
             .Replace('1', '0')
             .Replace('2', '1');

         return "1" + res;
     }
     static string AddC(string number)
    {  long num = Int64.Parse(number);
        if (num > 0)
        {
            
            return StrC(number);
        }
        else
        {
            string res = Sum(long.Parse(RevC(number)), 1 ).ToString();
            return res;
        }
        
    }
      static long Sum(long a, long b)
     {
         int mem = 0;
         string res = string.Empty;
         while (a != 0 || b != 0)
         {
             res = (a % 10 + b % 10 + mem) % 2 + res;
             mem = (int)((a % 10 + b % 10 + mem) / 2);
             a /= 10; b /= 10;
         }

         if (mem != 0)
         {
             res = mem + res;
         }

         return long.Parse(res);
     }
     static long SubL(long a, long b)
     {
         string bS = b.ToString();
         while (a.ToString().Length != bS.Length)
             bS= "0" + bS;
         // reverse b
         bS = bS.Replace('0', 'a')
             .Replace('1', '0')
             .Replace('a', '1');

         // add 1
         b = Sum(long.Parse(bS), 1);
         return long.Parse(Sum(a, b).ToString()[1..]);
     }
    
      static string ReverseSum(long a, long b)
     {
         string al =a.ToString();
         string bl = b.ToString();
        
         var aS = a > 0 ? StrC(al) : RevC(al);
         var bS = b > 0 ? StrC(bl) : RevC(bl);
         while (aS.Length < 7)
         {
             aS = aS[0] + '0' + aS[1..];
         }
         while (bS.Length < 7)
         {
             bS = bS[0] + '0' + bS[1..];
         }
         long res = Sum(int.Parse(aS), int.Parse(bS));
        
         if (res.ToString().Length > 7)
         {
             res = long.Parse(res.ToString()[1..]);
             res = SubL(res, 1);
         }
         return res.ToString();
     }
    
      static string AdditionalSum(long a, long b)
     {
         string al =a.ToString();
         string bl = b.ToString();
         var aS = a > 0 ? RevC(al) : AddC(al);
         var bS = b > 0 ? RevC(bl) : AddC(bl);
         while (aS.Length < 7)
         {
             aS = aS[0] + '0' + aS[1..];
         }
         while (bS.Length < 7)
         {
             bS = bS[0] + '0' + bS[1..];
         }
         long res = Sum(int.Parse(aS), int.Parse(bS));

         if (res.ToString().Length > 7)
         {
             res = long.Parse(res.ToString()[1..]);
             res = SubL(res, 1);
         }
         return res.ToString();
     }
      static string Normal(decimal number)
      {
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

     static double DeNormal(string normalizedNumber)
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
      static string NormalSum(string a, string b)
      {
          a = a.Replace(" ", "");
          b = b.Replace(" ", "");
          string[] ch1 = a.Split('*');
          string[] ch2 = b.Split('*');
          string[] exp1 = ch1[1].Split('^');
          string[] exp2 = ch2[1].Split('^');
          int nexp1 = Convert.ToInt32(exp2[1]);
          int nexp = Convert.ToInt32(exp1[1]) - Convert.ToInt32(exp2[1]);
          double res = (Convert.ToDouble(ch1[0]) * (int)(Math.Pow(10,nexp)) + Convert.ToDouble(ch2[0]))*(int)Math.Pow(10,nexp1);
          return res.ToString();
          //  return Normal((decimal)(DeNormal(a)) + (decimal)DeNormal(b));
      }
    
      static string NormalRazn(string a, string b)
     {
         a = a.Replace(" ", "");
         b = b.Replace(" ", "");
         string[] ch1 = a.Split('*');
         string[] ch2 = b.Split('*');
         string[] exp1 = ch1[1].Split('^');
         string[] exp2 = ch2[1].Split('^');
         int nexp = Convert.ToInt32(exp1[1]) - Convert.ToInt32(exp2[1]);
         int nexp1 = Convert.ToInt32(exp2[1]);
         double res = (Convert.ToDouble(ch1[0]) * (int)(Math.Pow(10,nexp)) - Convert.ToDouble(ch2[0]))*(int)Math.Pow(10,nexp1);
         return res.ToString();
       //  return Normal((decimal)(DeNormal(a)) - (decimal)DeNormal(b));
     }
       
      private static string NormalMutliply(string a, string b)
     {
         a = a.Replace(" ", "");
         b = b.Replace(" ", "");
         string[] ch1 = a.Split('*');
         string[] ch2 = b.Split('*');
         string[] exp1 = ch1[1].Split('^');
         string[] exp2 = ch2[1].Split('^');
         int nexp = Convert.ToInt32(exp1[1]) + Convert.ToInt32(exp2[1]);
         double res = (Convert.ToDouble(ch1[0]) * Convert.ToDouble(ch2[0]))*Math.Pow(10,nexp);
         return res.ToString();
         //  return Normal((decimal)(DeNormal(a)) * (decimal)DeNormal(b));
     }
    
      static string NormalDel(string a, string b)
     {
         a = a.Replace(" ", "");
         b = b.Replace(" ", "");
         string[] ch1 = a.Split('*');
         string[] ch2 = b.Split('*');
         string[] exp1 = ch1[1].Split('^');
         string[] exp2 = ch2[1].Split('^');
         int nexp = Convert.ToInt32(exp1[1]) - Convert.ToInt32(exp2[1]);
         double res = (Convert.ToDouble(ch1[0]) / Convert.ToDouble(ch2[0]))*Math.Pow(10,nexp);
         return res.ToString();
       //  return Normal((decimal)(DeNormal(a)) / (decimal)DeNormal(b));
     }
      
      static int Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Console.WriteLine("Choose task");
        string t = Console.ReadLine();
        switch (t)
        {
            case "1":
            {
                Console.WriteLine("Input a decimal number(10-2)");
                string number = Console.ReadLine();
                Console.WriteLine(DecimalToDb(number));
                break;
            }
            case "2":
            {
                Console.WriteLine("Input a number(2-10)");
                string number = Console.ReadLine();
                Console.WriteLine(DbToDecimal(number));
                break;
            }
             case "3":
            {
                Console.WriteLine("Input text");
                string text = Console.ReadLine();
                Console.WriteLine("Code: "+ TextToAscii(text));
                break;
            }
            case "4":
            {
                Console.WriteLine("Input ASCII code");
                string code = Console.ReadLine();
                Console.WriteLine("Text:" + AsciiToText(code));
                break;
            }
            case "5":
            {
                Console.WriteLine("Input number");
                string number = Console.ReadLine();
                Console.WriteLine("Straight Code " + StrC(number));
                Console.WriteLine("Reverse Code " +RevC(number));
                Console.WriteLine("Addictional code "+AddC(number));
                break;
            }
            case "6":
            {
                long a = Convert.ToInt64(Console.ReadLine());
                long b = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine(ReverseSum(a,b));
                Console.WriteLine(AdditionalSum(a,b));
                break;
            }
            case "7":
            {
                Console.WriteLine("Input number");
                decimal n = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(Normal(n));
                Console.WriteLine("Input number");
                string number = Console.ReadLine();
                Console.WriteLine(DeNormal(number));
                break;
            }
            case "8":
            {   Console.WriteLine("Input numbers");
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                Console.WriteLine(NormalSum(s1,s2));
                Console.WriteLine(Normal(Convert.ToDecimal(NormalSum(s1,s2))));
                Console.WriteLine(NormalRazn(s1,s2));
                Console.WriteLine(Normal(Convert.ToDecimal(NormalRazn(s1,s2))));
                Console.WriteLine(NormalMutliply(s1,s2));
                Console.WriteLine(Normal(Convert.ToDecimal(NormalMutliply(s1,s2))));
                Console.WriteLine(NormalDel(s1,s2));
                Console.WriteLine(Normal(Convert.ToDecimal(NormalDel(s1,s2))));
                break;
            }  
               
                
        }
        //Task1 
       
        //Task 2 
       
        //Task 3
        
        // Task 4
        
        // Task 5
       
        //Task 6
       /* //Task 7
        // Task 8*/

        return 0;
    }
}