using System;
using System.Collections.Generic;


public class Program
{
    internal static int Prioritet(string ch)
    {
        switch (ch)
        {
            case "+":
            case "-":
                return 1;

            case "*":
            case "/":
                return 2;

            case "^":
                return 3;
            default:
                return -1;
        }
    }


    public static Stack<string> Convert(string exp)
    {
        Stack<string> result = new Stack<string>();

        Stack<string> stack = new Stack<string>();

 
        foreach(var c in exp.Split(" ")) 
        {
            int n;
            if (int.TryParse(c, out n))
            {
                result.Push(c.ToString());
            }
            else // an operator is encountered
            {
                while (stack.Count > 0
                    && Prioritet(c.ToString()) <= Prioritet(stack.Peek()))
                {
                    result.Push(stack.Pop());
                }
                stack.Push(c.ToString());
            }
        }

        // pop all the operators from the stack
        while (stack.Count > 0)
        {
            result.Push(stack.Pop());
        }

        return result;
    }

    public static void Main(string[] args)
    {
        string exp = "52 + 3 * 2 / 10";

        Stack<string> s = Convert(exp);
        Console.WriteLine(Calculate(s));
    }

    private static int Calculate(Stack<string> chars)
    {
        Stack<string> operations = new();
        while(chars.Count - 1 != 0)
        {
            while (chars.Peek() == "+" ||
                   chars.Peek() == "-" ||
                   chars.Peek() == "+" ||
                   chars.Peek() == "/")
            {
                operations.Push(chars.Pop());
            }

            int res = 0;
            while(chars.Count != 0)
            {
                switch (operations.Pop())
                {
                    case "+":
                        res = int.Parse(chars.Pop()) + int.Parse(chars.Pop());
                        break;
                    case "-":
                        res = int.Parse(chars.Pop()) - int.Parse(chars.Pop());
                        break;
                    case "*":
                        res = int.Parse(chars.Pop()) * int.Parse(chars.Pop());
                        break;
                    case "/":
                        res = int.Parse(chars.Pop()) / int.Parse(chars.Pop());
                        break;
                }
            }

            chars.Push(res.ToString());
        }
        return int.Parse(chars.Pop());
    }
}
