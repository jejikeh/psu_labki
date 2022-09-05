using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task10
    {
        internal static void MoreThanHalfPositive(int[,] a)
        {
            for(int i = 0; i < a.GetLength(0); i++)
            {
                int positive = 0;
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i,j] > 0) positive++;
                }

                if(positive > a.GetLength(1) / 2)
                {
                    Console.WriteLine($"\nRow : {i}");
                }
            }
        }
    }
}
