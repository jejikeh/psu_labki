using System;
using System.Collections.Generic;


namespace Lab5;

public class STACK
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

    private static Dictionary<char, int> Operators = new Dictionary<char, int>()
    {
        { '+', 1 },
        { '-', 1 },
        { '*', 2 },
        { '/', 2 },
        { '^', 3 }
    };

    // The main method that converts given infix expression
    // to prefix expression.
    public static string InfixToPrefix(string exp)
    {
        Stack<char> ops = new();

        string result = string.Empty;
        
        for (int i = 0; i < exp.Length; i++)
        {
            // If char is letter or digit then add to result string
            if (char.IsLetterOrDigit(exp[i]))
                result = exp[i] + result;
            
            // if char is operator
            if (Operators.ContainsKey(exp[i]))
            {
                // if in stack are ops with higher prior 
                while (ops.Count > 0 && Operators[exp[i]] <= Operators[ops.Peek()])
                {
                    result = ops.Pop() + result;
                }
                // push operator to stack
                ops.Push(exp[i]);
            }
        }
        
        while (ops.Count != 0)
        {
            result = ops.Pop() + result;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        var exp = "A+B*C+D";

        string res = InfixToPrefix(exp);
        Console.WriteLine(res);
        
        // 2 task

        List<HospitalTask.Hospital> hospitals = new List<HospitalTask.Hospital>();
        hospitals.Add(new HospitalTask.Hospital(10,42));
        hospitals.Add(new HospitalTask.Hospital(1,4));
        hospitals.Add(new HospitalTask.Hospital(245,152));

        var patient1 = new HospitalTask.Patient("Vanya",23,hospitals);
        var patient2 = new HospitalTask.Patient("Alex",2,hospitals);
        var patient3 = new HospitalTask.Patient("Sasha",356,hospitals);
        var patient4 = new HospitalTask.Patient("Oleg",2,hospitals);
        
        
        Console.WriteLine("\n\tHospital 1");
        hospitals[0].PrintInfo();
        
        Console.WriteLine("\n\tHospital 2");
        hospitals[1].PrintInfo();
        
        Console.WriteLine("\n\tHospital 3");
        hospitals[2].PrintInfo();

        
        hospitals[0].DischargePatient();
        
        Console.WriteLine("\n\tHospital 1 edited");
        hospitals[0].PrintInfo();
    }
}

