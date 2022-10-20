using System;
using System.Linq;
using  System.Collections.Generic;

public class MainClass
{
    public static void Main()
    {
        Console.ReadLine();
        var inputString = Console.ReadLine()!.Split(' ');

        var input = inputString.Select(x => int.Parse(x)).ToList();

        var counts = new Dictionary<int, int>();
        foreach (var x in input.Where(x => !counts.ContainsKey(x)))
        {
            counts.Add(x, input.Count(y => y == x));
        }

        var output = new List<int>();
        for (var k = 0; k < 11; k++)
        {
            if (!counts.ContainsKey(k)) continue;
            
            for (var j = 0; j < counts[k]; j++)
                output.Add(k);
        }

        Console.WriteLine($"{string.Join(" ", output)}");
    }
}