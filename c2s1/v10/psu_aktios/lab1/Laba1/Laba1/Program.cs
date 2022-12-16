namespace Laba1;

static class Laba1

{ //Метод перевода из десятичной в 2,8,16
    static string DecimalTo(string number, int foot)
    {
        Dictionary<int, char> letters = new();
        letters.Add(0, '0');
        letters.Add(1, '1');
        letters.Add(2, '2');
        letters.Add(3, '3');
        letters.Add(4, '4');
        letters.Add(5, '5');
        letters.Add(6, '6');
        letters.Add(7, '7');
        letters.Add(8, '8');
        letters.Add(9, '9');
        letters.Add(10, 'A');
        letters.Add(11, 'B');
        letters.Add(12, 'C');
        letters.Add(13, 'D');
        letters.Add(14, 'E');
        letters.Add(15, 'F');
        
        if (number.Contains('.'))
        {
            string[] num = number.Split('.');
            num[1] = "0." + num[1];
            long left = Convert.ToInt64(num[0]);
            double right = Convert.ToDouble(num[1]);
            num[0] = string.Empty;
            num[1] = string.Empty;
            number = string.Empty;
            while (left != 0)
            {
                num[0] = letters[(int)left % foot] + num[0];
                left = left / foot ;
            }
            for (int i=0 ; i < 4 ;i++)
            {
                right = right * foot;
                num[1] = num[1] + letters[(int)right];
                right -= (int)right;
            }
            number = num[0] + "." + num[1];
        }
        else
        {
            long left = Convert.ToInt64(number);
            number = String.Empty;
            while (left != 0)
            {
                number = letters[(int)left % foot] + number;
                left = left / foot ;
            } 
        }
      
        
        return number;
    }
    //В десятичную
    static string ToDecimal(string number, int foot)
    {
        
        if (number.Contains('.'))
        {
            string[] num = number.Split('.');
            int indexl = num[0].Length - 1;
            int indexr = num[1].Length*(-1);
            int resl = 0;
            double resr = 0;
            for (int i=0;i<=num[0].Length-1;i++)
            {
                resl=resl+(int.Parse(num[0][i].ToString())*Convert.ToInt32(Math.Pow(foot, indexl)));
                indexl--;
            }
            for (int i=0;i<num[1].Length;i++)
            {
                resr=resr+(int.Parse(num[1][i].ToString())*Convert.ToDouble(Math.Pow(foot, indexr)));
                indexl++;
            }
            number = string.Empty;
            number = Convert.ToString(resl+resr);
        }
        else
        {
            int index = number.Length - 1;
            int res = 0;
            for (int i=0;i<=number.Length-1;i++)
            {
                res=res+(int.Parse(number[i].ToString())*Convert.ToInt32(Math.Pow(foot, index)));
                index--;
            }
            number = string.Empty;
            number = Convert.ToString(res);
        }

        return number;
    }

    static string Sum(string expression,int foot)
    {
        if (expression.Contains('.'))
        { 
            string[] num = expression.Split('+');
            int mem = 0;
            string res = string.Empty;
            string rightRes = string.Empty;
            if (!num[0].Contains('.'))
            {
                num[0] += ".0";
            }
            else
            {
                num[1] += ".0";
            }
            string[] num1 = num[0].Split('.'); // 0 save as a 
            string[] num2 = num[1].Split('.');
            long rightA = long.Parse(num1[1]);
            long rightB = long.Parse(num2[1]);
            while (rightA != 0 || rightB != 0)
            {
                rightRes = (rightA % 10 + rightB % 10 + mem) % foot + rightRes;
                mem = (int)((rightA % 10 + rightB % 10 + mem) / foot);
                rightA /= 10;
                rightB /= 10;
            }

            long al = long.Parse(num1[0]);
            long bl = long.Parse(num2[0]);
            while (al != 0 || bl != 0)
            {
                res = (al % 10 + bl % 10 + mem) % foot + res;
                mem = (int)((al % 10 + bl % 10 + mem) / foot);
                al /= 10;
                bl /= 10;
            }

            if (mem != 0)
            {
                res = mem + res;
            } 
            expression =  res + "." + rightRes;
        }
        else
        {
            string[] num = expression.Split('+');
            int mem = 0;
            string res = string.Empty;
            long al = long.Parse(num[0]);
            long bl = long.Parse(num[1]);
            while (al != 0 || bl != 0)
            {
                res = (al % 10 + bl % 10 + mem) % foot + res;
                mem = (int)((al % 10 + bl % 10 + mem) / foot);
                al /= 10;
                bl /= 10;
            }

            if (mem != 0)
            {
                res = mem + res;
            }

            expression =  res;
        }
     
        return expression;
    }
    static string RaznG(string expression, int foot)//1 больше 2 + ,
  {
      string[] num = expression.Split('-');
          long meml = 0;
          long memr = 0;
          string res = string.Empty;
          string rightRes = string.Empty;
          string leftRes = string.Empty;
          if (!num[0].Contains('.')&&!num[1].Contains('.'))
          {
              num[0] += ".0";
              num[1] += ".0";
          }
          else if (!num[1].Contains('.'))
          {
              num[1] += ".0";
          }
          else
          {
              num[0] += ".0";
          }
          
          string[] num1 = num[0].Split('.');
          int num1r = num1[1].Length;
          int num1l = num1[0].Length;
          string[] num2 = num[1].Split('.');
          int num2r = num2[1].Length;
          int num2l= num2[0].Length;
          while (num1r != num2r)
          {
              var p1= num1r > num2r ? num2[1]+='0' : num2[1]+='0';
              var p2= num1r > num2r ? num2r++ : num1r++;
          }

          while (num1l != num2l)
          {
              var c1= num1l > num2l ? num2[0]= '0'+num2[0]: num1[0]='0'+num1[0];
              var c2 = num1l > num2l ? num2l++ : num1l++;
          }
          for (int i = num1[1].Length-1; i >= 0; i--)
          {
              string buffr = "";
              int RightA = Math.Abs(Convert.ToInt32(new string (num1[1][i],1)));
              int RightB = Math.Abs(Convert.ToInt32(new string (num2[1][i],1)));
              if (RightA < RightB)
              {
                  int j = i;

                  if (num1[1][j] == '0')
                  {
                      while (num1[1][j] == '0')
                      {
                          buffr = Convert.ToString(foot - 1);
                          char[] arr = num1[1].ToCharArray();
                          arr[j] = Convert.ToChar(buffr);
                          num1[1] = new string(arr);
                          j--;
                      }
                  }
                  if(num1[1][j] != '0'&&foot==8)
                  {
                      j--;
                      char[] arrBuf = num1[1].ToCharArray();
                      arrBuf[j] = Convert.ToChar(Convert.ToInt32(num1[1][j]) - 1);
                      num1[1] = new string(arrBuf);
                      RightA = Convert.ToInt32(new string(num1[1][j], 1));
                      memr = foot + RightA - RightB;
                  }
                  else
                  {
                      char[] arrBuf = num1[1].ToCharArray();
                      arrBuf[j] = Convert.ToChar(Convert.ToInt32(num1[1][j]) - 1);
                      num1[1] = new string(arrBuf);
                      RightA = Convert.ToInt32(new string(num1[1][j], 1));
                      memr = foot+RightA - RightB;
                  }
              } 
          
              else
              {
                  memr = RightA - RightB;
              }
              rightRes= memr.ToString() + rightRes;
          }
          
          for (int i = num1[0].Length-1; i >= 0; i--)
          {
              string buff = "";
              int LeftA = Math.Abs(Convert.ToInt32(new string (num1[0][i],1)));
              int LeftB = Math.Abs(Convert.ToInt32(new string (num2[0][i],1)));
 
              if (LeftA < LeftB)
              {
                  int j = i;

                  if (num1[0][j] == '0')
                  {
                      while (num1[0][j] == '0')
                      {
                          buff = Convert.ToString(foot - 1);
                          char[] arr = num1[0].ToCharArray();
                          arr[j] = Convert.ToChar(buff);
                          num1[0] = new string(arr);
                          j--;
                      }
                  }
                  if(num1[0][j] != '0'&&foot==8)
                  {
                          j--;
                          char[] arrBuf = num1[0].ToCharArray();
                          arrBuf[j] = Convert.ToChar(Convert.ToInt32(num1[0][j]) - 1);
                          num1[0] = new string(arrBuf);
                          LeftA = Convert.ToInt32(new string(num1[0][j], 1));
                          meml = foot + LeftA - LeftB;
                      }
                  else
                  {
                      char[] arrBuf = num1[0].ToCharArray();
                          arrBuf[j] = Convert.ToChar(Convert.ToInt32(num1[0][j]) - 1);
                          num1[0] = new string(arrBuf);
                          LeftA = Convert.ToInt32(new string(num1[0][j], 1));
                          meml = foot+LeftA - LeftB;
                  }
              } 
          
              else
              {
                  meml = LeftA - LeftB;
              }
              leftRes = meml.ToString() + leftRes;
          }

          expression = leftRes + '.' + rightRes;
          return expression;
  }
    static string Razn(string number,int foot)
    {
        string[] num = number.Split('-');
        double res1 = Double.Parse(ToDecimal(num[0], foot));
        double res2 =  Double.Parse(ToDecimal(num[1], foot));
        return DecimalTo(Convert.ToString(res1 - res2),foot);
    }
    static string Umnozh(string number, int foot)
    {
        string[] num = number.Split('*');
        double res1 = Double.Parse(ToDecimal(num[0], foot));
        double res2 =  Double.Parse(ToDecimal(num[1], foot));
        return DecimalTo(Convert.ToString(res1 * res2),foot);
    }
    // Главная
    static int Main()
    { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Console.WriteLine("Choose task: ");
        int t = Convert.ToByte(Console.ReadLine());
        switch (t)
        {
            case 1:
            {
                Console.WriteLine("Input a decimal number(10-2)");
                string number = Console.ReadLine();
                Console.WriteLine(DecimalTo(number, 2));
                Console.WriteLine("Input a decimal number(10-8)");
                number = Console.ReadLine();
                Console.WriteLine(DecimalTo(number, 8));
                Console.WriteLine("Input a decimal number(10-16)");
                number = Console.ReadLine();
                Console.WriteLine(DecimalTo(number, 16));
                break;
            }
            case 2:
            {
                Console.WriteLine("Input a number(2-10)");
                string number = Console.ReadLine();
                Console.WriteLine(ToDecimal(number, 2));
                Console.WriteLine("Input a number(8-10)");
                number = Console.ReadLine();
                Console.WriteLine(ToDecimal(number, 8));
                break;
            }
            case 3:
            {
                Console.WriteLine("Input a decimal number");
                string number = Console.ReadLine();
                Console.WriteLine(Convert.ToString(Sum(number, 2)));
                Console.WriteLine("Input a decimal number");
                number = Console.ReadLine();
                Console.WriteLine(Convert.ToString(Sum(number, 8)));
                break;
            }
            case 4:
            { 
                Console.WriteLine("Input a decimal expression");
               string number = Console.ReadLine();
               Console.WriteLine(Convert.ToString(RaznG(number,2)));
                Console.WriteLine(Convert.ToString(Razn(number,2)));
                Console.WriteLine("Input a decimal expression");
                number = Console.ReadLine();
                Console.WriteLine(Convert.ToString(RaznG(number,8)));
                Console.WriteLine(Convert.ToString(Razn(number, 8)));
                break;
            }
            case 5:
            {
                Console.WriteLine("Input a decimal number");
                string number = Console.ReadLine();
                Console.WriteLine(Convert.ToString(Umnozh(number, 2)));
                Console.WriteLine("Input a decimal number");
                number = Console.ReadLine();
                Console.WriteLine(Convert.ToString(Umnozh(number, 8)));
                break;
            }

        }

        return 0;
    }
}