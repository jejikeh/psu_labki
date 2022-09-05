using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task6
    {
        internal static void MinInCollumn(int[,] a)
        {
            for(int i = 0;i < a.GetLength(1); i++)
            {
                int min = int.MaxValue;
                for(int j = 0; j < a.GetLength(0); j++)
                {
                    if (a[j, i] < min) min = a[j, i];
                }

                Console.WriteLine($"Min element in {i} collumn - {min}");
            }
        }

        internal static int MinInCollumnValue(int[,] a, int i)
        {
            int min = int.MaxValue;
            for (int j = 0; j < a.GetLength(0); j++)
            {
                if (a[j, i] < min) min = a[j, i];
            }
            return min;
        }

        internal static void MaxInRow(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > max) max = a[i, j];
                }

                Console.WriteLine($"Max element in {i} row - {max}");
            }
        }

        internal static int MaxInRowValue(int[,] a, int i)
        {
            int max = int.MinValue;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] > max) max = a[i, j];
            }

            return max;
        }
    }
}
