using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task4
    {
        internal static void Replace(ref int[,] a)
        {
            bool wasFound = false;
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i,j] % 2 == 0)
                    {
                        a[i,j] = a[i,j] / 2;
                        wasFound = true;
                    }
                }
            }

            if (!wasFound)
            {
                Console.WriteLine("There are no numbers that are multiples of two");
            }
        }
    }
}
