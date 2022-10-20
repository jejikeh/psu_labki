using System;
using System.Collections.Generic;
using System.Linq;

public class MainClass
{
    static int[] p;
    static int[] H;
    static int l;

    static void Set(int i, int x)
    {
        if (i > l) return;
        if (p[i] < p[x] + 1) return;

        H[i] = x;
        p[i] = p[x] + 1;
    }

    static void Main()
    {
        var inp0 = Console.ReadLine().Split(' ');
        l = int.Parse(inp0[0]);
        p = new int[l + 1];
        H = new int[l + 1];
        p = Enumerable.Range(-1, l + 1).ToArray();
        H = Enumerable.Range(-1, l + 1).ToArray();

        for (var i = 1; i < l; i++)
        {
            var dd = i + i;
            Set(dd, i);
            Set(dd + 1, dd);
            var tt = dd + i;
            Set(tt, i);
            Set(tt + 1, tt);
            Set(tt + 2, tt + 1);
        }

        List<int> oper = new List<int>();
        oper.Add(l);
        var last = l;
        while (H[last] > 0)
        {
            last = H[last];
            oper.Add(last);
        }
        Console.WriteLine(oper.Count - 1);
        Console.WriteLine(String.Join(" ", oper.OrderBy(x => x)));
    }
}