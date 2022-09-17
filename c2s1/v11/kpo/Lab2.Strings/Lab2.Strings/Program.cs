
using LabL;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

Console.WriteLine("Task1!!!\n\n");

{
    string input = "qwertyuiop";
    for(int i = 0; i < input.Length; i += 3)
    {
        if (i > input.Length) break;
        Console.Write(input[i]);
    }
}

Console.WriteLine("\nTask2!!!\n\n");

{
    string input = "ff33g2";
    int num = 0;
    for (int i = 0; i < input.Length; i++)
    {
        int t = 0;
        if (int.TryParse(input[i].ToString(), out t))
        {
            num++;
        }
    }

    Console.WriteLine(num);
}


Console.WriteLine("Task3!!!\n\n");

{
    string input = "ff33g2 ddd es ef deaf";
    var worlds = input.Split(" ");
    int numLength = int.MinValue;

    foreach (var w in worlds)
    {
        if (w.Length > numLength) numLength = w.Length;
    }
    Console.WriteLine(numLength);
}

Console.WriteLine("\n\nTask1\n\n");

{
    string input = "babajiy hello world afganistan";
    List<World> worldList = new List<World>();
    var worlds = input.Split(" ");

    int maxCountVowels = int.MinValue;
    foreach(var worl in worlds)
    {
        worldList.Add(new World(worl));
        if (worldList.Last().Vowels > maxCountVowels) maxCountVowels = worldList.Last().Vowels;
    }

    List<string> res = new();
    foreach(var ch in worldList.Where(x => x.Vowels == maxCountVowels))
    {
        res.Add(ch.Text);
    }
    
    Console.WriteLine("\tmax vowels in alpabetical order");
    res.Sort();
    res.ForEach(x =>
    {
        Console.WriteLine(x);
    });

    Console.WriteLine("\ta more than 1");
    worldList.ForEach(x =>
    {
        if (x.Text.Count(x => x == 'a') > 1)
        {
            Console.WriteLine(x.Text);
        }
    });
}

Console.WriteLine("\n\nTask2\n\n");

{
    string input = "2512 *3/(35+1)";

    Expression expression = new Expression(input);
    var result = expression.Parse();
    Console.WriteLine(expression.Intepreter(result));
}

Console.WriteLine("\n\nTask3\n\n");
{
    string input = "(3*2)";
    //string input = "(";
    Expression expression = new Expression(input);
    var tokens = expression.Parse();

}

Console.WriteLine("\n\nTask4\n\n");
{
    string input = @"c:\\WebServers\\home\\testsite\\www\\myfile.txt";

    string fileName = string.Empty;
    foreach (var ch in input.Reverse())
    {
        if(ch.ToString() == @"\")
        {
            break;
        }
        fileName = ch + fileName;
    }

    Console.WriteLine(fileName);
}


Console.WriteLine("\n\nTask4\n\n");

{
    var unsorted = "abcdefgklmnpe".ToList();
    List<char> sorted = new();
    sorted.AddRange(unsorted);
    sorted.Sort();

    for(int i = 0; i < unsorted.Count; i++)
    {
        if (unsorted[i] != sorted[i])
        {
            Console.WriteLine($"{i} element");
            break;
        }
    }
}

Console.WriteLine("\n\nTask5\n\n");

{
    var input = "(ab){cd}[ef]";

    Tuple<int, int> round = new Tuple<int, int>(0,0);
    Tuple<int, int> wavy = new Tuple<int, int>(0, 0);
    Tuple<int, int> square = new Tuple<int, int>(0, 0);
    foreach (var ch in input)
    {
        if (ch == '(') round = new Tuple<int, int>(round.Item1 + 1, round.Item2);
        if (ch == ')') round = new Tuple<int, int>(round.Item1, round.Item2 + 1);
        if (ch == '{') wavy = new Tuple<int, int>(wavy.Item1 + 1, wavy.Item2);
        if (ch == '}') wavy = new Tuple<int, int>(wavy.Item1, wavy.Item2 + 1);
        if (ch == '[') square = new Tuple<int, int>(square.Item1 + 1, square.Item2);
        if (ch == ']') square = new Tuple<int, int>(square.Item1, square.Item2 + 1);
    }

    if(round.Item1 > round.Item2 || wavy.Item1 > wavy.Item2 || square.Item1 > square.Item2)
    {
        Console.WriteLine("More open than closed");
    }
    else if (round.Item1 < round.Item2 || wavy.Item1 < wavy.Item2 || square.Item1 < square.Item2)
    {
        Console.WriteLine("More closed than open ");
    }
    else
    {
        Console.WriteLine("yes");
    }
}

Console.WriteLine("\n\nTask6\n\n");


{
    string input1 = "fes1124ddsad352";
    string input2 = "sdfih22";

    string r1 = string.Empty, r2 = string.Empty;

    for(int i = 0; i < input1.Length; i++)
    {
        int res;
        string tr = string.Empty;
        while (int.TryParse(input1[i].ToString(),out res))
        {
            tr += res;
            i++;
            if (i == input1.Length) break;
        }
        
        if(r1.Length < tr.Length)
        {
            r1 = tr;
        }
    }

    for (int i = 0; i < input2.Length; i++)
    {
        int res;
        string tr = string.Empty;
        while (int.TryParse(input2[i].ToString(), out res))
        {
            tr += res;
            i++;
            if (i == input2.Length) break;
        }

        if (r2.Length < tr.Length)
        {
            r2 = tr;
        }
    }

    Console.WriteLine(r1 + r2);
}


Console.WriteLine("\n\nTask7\n\n");
{
    string s1 = "aabboobb";
    string s2 = "bb";
    string s3 = "vv";


    Console.WriteLine(s1.Replace(s2, s3));
}

Console.WriteLine("\n\nTask8\n\n");

{
    string input1 = "aavv 333 fhh 34234 hgg";
    for (int i = 0; i < input1.Length; i++)
    {
        int res;
        string tr = string.Empty;
        if (i !=0 && input1[i - 1] == ' ') { 
            while (int.TryParse(input1[i].ToString(), out res))
            {
                tr += res;
                i++;
                if (i == input1.Length) break;
            }
        }
        if (input1[i] == ' ')
        {
            input1 = input1.Replace(" " + tr + " ", "< " + tr + " >");
        }
    }

    Console.WriteLine(input1);
}


// task 39
{
    string input = "##ddd## ##ddd## ### deduh# fjrifsfsghs";
    var worlds = input.Split(" ");
    Regex x = new Regex(@"^\#[\s\S]*?\#+");


    string res = string.Empty;
    foreach(var w in worlds)
    {
        if (x.IsMatch(w))
        {
            res += "<" + w.Replace("##","") + ">";
        }
        else
        {
            res += w;
        }
    }

    Console.WriteLine(res);
    
}

{
    List<string> reference = new List<string>()
    {
        "hello",
        "world"
    };

    string input = "helpo world hel";
    var worlds = input.Split(" ");

    string res = string.Empty;
    foreach (var s in reference)
    {
        int errors = 0;
        foreach(var w in worlds)
        {
            int i = 0;
            string ww = w;
            string ss = s;

            while (ww.Length < ss.Length)
            {
                ww += " ";
            }

            while (ww.Length < ss.Length)
            {
                ss += " ";
            }

            while (ww[i] != ss[i])
            {
                errors++;
                i++;
                if (i == ww.Length || i == ss.Length) break;
            }

            if(errors < 1)
            {
                res += s + " ";
            }
            else
            {
                res += w + " ";
            } 
        }
    }

    Console.WriteLine(res.Substring(0,res.Length/2));
}