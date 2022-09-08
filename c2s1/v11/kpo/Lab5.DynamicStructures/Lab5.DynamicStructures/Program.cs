using System;
using System.Collections.Generic;


public class Program
{
    internal static int Prec(string ch)
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
        }
        return -1;
    }

    // The main method that converts given infix expression
    // to postfix expression.
    public static Stack<string> infixToPostfix(string exp)
    {
        // initializing empty String for result
        Stack<string> result = new Stack<string>();

        // initializing empty stack
        Stack<string> stack = new Stack<string>();

        var worlds = exp.Split(" ");
        foreach (var c in worlds) {

            // If the scanned character is an
            // operand, add it to output.
            int n;
            if (int.TryParse(c, out n))
            {
                result.Push(c);
            }

            // If the scanned character is an '(',
            // push it to the stack.
            else if (c == "(")
            {
                stack.Push(c);
            }

            //  If the scanned character is an ')',
            // pop and output from the stack
            // until an '(' is encountered.
            else if (c == ")")
            {
                while (stack.Count > 0
                       && stack.Peek() != "(")
                {
                    result.Push(stack.Pop());
                }

                if (stack.Count > 0
                    && stack.Peek() != "(")
                {
                    return new Stack<string>(); // invalid
                                                 // expression
                }
                else
                {
                    stack.Pop();
                }
            }
            else // an operator is encountered
            {
                while (stack.Count > 0
                       && Prec(c) <= Prec(stack.Peek()))
                {
                    result.Push(stack.Pop());
                }
                stack.Push(c);
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
        string exp = "A+B*C+D";

        Stack<string> res = infixToPostfix(exp);
        Console.WriteLine(res);
    }


}
