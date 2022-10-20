using System;

public class MainClass
{
    public static void Main()
    {
        var input1 = Console.ReadLine();
        var input2 = Console.ReadLine();


        var results = new List<int>();
        foreach (var ch in input1)
        {
            results.Add(Math.Abs(input1.IndexOf(ch) - input2.IndexOf(ch)) - 1);
        }
        
        Console.WriteLine(results.Max());
    }
}