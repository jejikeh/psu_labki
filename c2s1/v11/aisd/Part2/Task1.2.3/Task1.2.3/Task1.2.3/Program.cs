using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;


public class MainClass
{
    private const int RootIndex = -1;
    
    public static void Main()
    {
        Console.ReadLine();
        var parents = Console
            .ReadLine()!
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        Console.WriteLine(GetHeight(parents));
    }

    private static int GetHeight(int[] parents)
    {
        return Enumerable.Range(0, parents.Length).Select(index => GetHeight(parents, index)).Max();
    }
    
    private static int GetHeight(int[] parents, int index)
    {
        return parents[index] != RootIndex ? 1 + GetHeight(parents, parents[index]) : 1;
    }
    
}