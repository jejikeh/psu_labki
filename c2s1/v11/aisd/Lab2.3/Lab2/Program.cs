using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();

        int x = int.Parse(input.Split(' ')[0]);
        int y = int.Parse(input.Split(' ')[1]);

        /*
        if(x == y && x != 0) {
            Console.WriteLine(x);
            return;
        }
        int nod = 0;
        for (int i = 1; i < Math.Min(x,y); i++)
        {
            if (x % i == 0 && y % i == 0)
            {
                nod = i;
            }
            
        }
        if (nod == 0)
            nod = 1;

        */
        Console.WriteLine(NOD(x,y));
    }

    private static int NOD(int x, int y)
    {
        if(y == 0)
             return x;

        return NOD(y, x % y);
    }
}