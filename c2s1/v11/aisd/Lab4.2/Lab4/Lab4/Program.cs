using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<string, char> map = new Dictionary<string, char>();

        string lengths = Console.ReadLine();
        var l = lengths.Split(" ");
        int uniqueChars = Int32.Parse(l.First());

        for (int i = 0; i < uniqueChars; i++)
        {
            var input = Console.ReadLine().Split(": ");
            map.Add(input.Last(), input.First()[0]);
        }

        string coded = Console.ReadLine();
        string decoded = String.Empty;
        
        string token = string.Empty;
        foreach (var ch in coded)
        {
            token += ch;
            if (map.ContainsKey(token))
            {
                decoded += map[token];
                token = String.Empty;
            }
        }
        
        Console.WriteLine(decoded);
    }
}