using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task1
    {
        private static Random _random = new();

        internal static void InitArray(ref int[,] a, int min = 30, int max = 75)
        {
            /// Create array, calc average for column
            for (int c = 0; c < a.GetLength(1); c++)
            {
                for (int r = 0; r < a.GetLength(0); r++)
                {
                    a[r, c] = _random.Next(min, max);
                }
            }
        }

        internal static void PrintArray(int[,] a)
        {
            for (int r = 0; r < a.GetLength(0); r++)
            {
                for (int c = 0; c < a.GetLength(1); c++)
                {
                    Console.Write(a[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }

        internal static void PrintAverages(int[,] a)
        {
            Stack<float> averages = new();

            for (int c = 0; c < a.GetLength(1); c++)
            {
                float average = 0;
                for (int r = 0; r < a.GetLength(0); r++)
                {
                    average += a[r, c];
                }
                averages.Push(average / a.GetLength(0));
            }

            foreach (float av in averages.Reverse())
            {
                Console.Write(av + "\t");
            }
        }
    }
}
