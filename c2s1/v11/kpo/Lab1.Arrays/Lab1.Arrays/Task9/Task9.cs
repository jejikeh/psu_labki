using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task9
    {
        internal static int SumOfMinInRow(int[,] a)
        {
            int sum = 0;
            for(int i = 0; i < a.GetLength(0); i++)
            {
                sum += Task6.MinInCollumnValue(a,i);
            }

            return sum;
        }
    }
}
