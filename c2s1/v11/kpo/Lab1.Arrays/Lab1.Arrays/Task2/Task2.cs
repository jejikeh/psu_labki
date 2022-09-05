using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task2
    {
        internal static int MainDiagonalSum(int[,] a)
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                sum += a[i, i] + a[a.GetLength(0) - i - 1, i];
            }

            return sum;
        }
    }
}
