﻿using System.Runtime.ExceptionServices;
using TaskL;

Console.WriteLine("\n\n\nTask 1! : 2");
{
    int[,] a = new int[10, 50];
    Task1.InitArray(ref a);
    Console.WriteLine(Task3.MaxEvenElement(a));

}

Console.WriteLine("\n\n\nTask 2! : 12");
{
    int[,] a = new int[1,5];
    Task1.InitArray(ref a);
    for(int i = 0; i < a.GetLength(1) - 1; i++)
    {
        if (a[0,i] % 2 == 0)
        {
            Console.WriteLine("EVEN : " + a[0,i]);
            break;
        }
    }

}

Console.WriteLine("\n\n\nTask 3! : 22");
{
    int[,] a = new int[5, 5];
    Task1.InitArray(ref a);
    Task1.PrintArray(a);
    
    int n = 3;
    for (int i = 0; i < a.GetLength(0) - 1; i++)
    {
        for (int k = 0; k < a.GetLength(1) - 1; k++)
        {
            if (a[i, k] % n == 0)
            {
                a[i,k] = a[i,k] / n;
            }
        }
    }

    Task1.PrintArray(a);

}

Console.WriteLine("\n\n\nTask 1 : 31");
{
    /// Task1
    int[,] a = new int[4, 6];

    Task1.InitArray(ref a);
    Task1.PrintArray(a);
    Task1.PrintAverages(a);
}

Console.WriteLine("\n\n\nTask 2 : 32");
{
    /// Task2
    int[,] a = new int[4, 4];

    Task1.InitArray(ref a);
    Console.WriteLine(Task2.MainDiagonalSum(a));   
}

Console.WriteLine("\n\n\nTask 3 : 33");
{
    /// Task3
    int[,] a = new int[4, 4];

    Task1.InitArray(ref a);
    Task3.PrintMinElement(a);
}

Console.WriteLine("\n\n\nTask 4 : 34");
{
    /// Task4
    int[,] a = new int[4, 4];

    Task1.InitArray(ref a);
    Task1.PrintArray(a);
    Console.WriteLine("--------");
    Task4.Replace(ref a);
    Task1.PrintArray(a);
}

Console.WriteLine("\n\n\nTask 5  : 35");
{
    /// Task5
    int[,] a = new int[4, 4];

    Task1.InitArray(ref a);
    Console.WriteLine("Absolute min index : " + Task5.AbsoluteMinIndex(a));
}

Console.WriteLine("\n\n\nTask 6  : 36");
{
    /// Task6
    int[,] a = new int[4, 4];

    Task1.InitArray(ref a);
    Task6.MinInCollumn(a);
    Task6.MaxInRow(a);
}

Console.WriteLine("\n\n\nTask 7  : 37");
{
    /// Task7
    int[,] a = new int[4, 4];

    Task1.InitArray(ref a);
    Task1.PrintArray(a);
    Console.WriteLine("--------");
    Task7.SwapMinAndMax(ref a);
    Task1.PrintArray(a);

}

Console.WriteLine("\n\n\nTask 8  : 38");
{
    /// Task8
    int[,] a = new int[4, 4];

    Task1.InitArray(ref a);
    Task8.PrintMaxRow(a);

}

Console.WriteLine("\n\n\nTask 9  : 39");
{
    /// Task9
    int[,] a = new int[5, 5];

    Task1.InitArray(ref a);
    Task1.PrintArray(a);
    Console.WriteLine(Task9.SumOfMinInRow(a));

}

Console.WriteLine("\n\n\nTask 10  : 40");
{
    /// Task10
    int[,] a = new int[4, 5];

    Task1.InitArray(ref a,-100,100);
    Task1.PrintArray(a);
    Task10.MoreThanHalfPositive(a);

}