using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskL
{
    internal static class Task7
    {
        internal static void SwapMinAndMax(ref int[,] a)
        {
            var minElement = a[Task3.MinElement(a).Item1, Task3.MinElement(a).Item2];

            a[Task3.MinElement(a).Item1, Task3.MinElement(a).Item2] = 
                a[Task3.MaxElement(a).Item1, Task3.MaxElement(a).Item2];

            a[Task3.MaxElement(a).Item1, Task3.MaxElement(a).Item2] = minElement;
        }
    }
}
