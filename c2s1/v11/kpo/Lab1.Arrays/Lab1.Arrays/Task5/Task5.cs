using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task5
    {
        internal static string AbsoluteMinIndex(int[,] a)
        {
            int min = int.MaxValue;
            string index = string.Empty;
            for(int i = 0; i < a.GetLength(0); i++)
            {
                int max = a[0, a.GetLength(1) - 1];
                int savedRow = 0;
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    max = Math.Max(max, a[i,j]);
                    if (max == a[i, j]) savedRow = j;
                }

                if (max < min)
                {
                    min = max;
                    index = $"{i} : {savedRow}";
                }
            }

            return index;
        }
    }
}
