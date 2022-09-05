using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task8
    {
        internal static void PrintMaxRow(int[,] a)
        {
            int maxSum = int.MinValue;
            int maxRow = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int sum = 0;
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    sum += a[i, j];
                }

                if (sum > maxSum) {
                    maxSum = sum;
                    maxRow = i;
                }
            }

            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[maxRow,j] + " ");
            }
        }
    }
}
