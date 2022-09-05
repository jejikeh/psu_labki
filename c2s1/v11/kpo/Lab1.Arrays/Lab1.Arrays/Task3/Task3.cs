using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task3
    {
        internal static void PrintMinElement(int[,] a)
        {
            int minimal = int.MaxValue;
            string index = string.Empty;
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int k = 0; k < a.GetLength(1); k++)
                {
                    if (a[i, k] < minimal) {
                        minimal = a[i, k];
                        index = $"{i} : {k}";
                    }
                }
            }

            Console.WriteLine($"Minimal {minimal} at index {index}");
        }

        internal static Tuple<int,int> MinElement(int[,] a)
        {
            int minimal = int.MaxValue;
            Tuple<int,int> index = new Tuple<int, int>(0,0);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    if (a[i, k] < minimal)
                    {
                        minimal = a[i, k];
                        index = new Tuple<int, int>(i,k);
                    }
                }
            }

            return index;
        }

        internal static Tuple<int, int> MaxElement(int[,] a)
        {
            int max = int.MinValue;
            Tuple<int, int> index = new Tuple<int, int>(0, 0);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    if (a[i, k] > max)
                    {
                        max = a[i, k];
                        index = new Tuple<int, int>(i, k);
                    }
                }
            }

            return index;
        }
    }
}
