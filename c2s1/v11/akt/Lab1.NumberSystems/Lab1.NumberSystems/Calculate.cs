using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.NumberSystems
{
    internal static class Calculate
    {
        internal static class Binary
        {

            internal static string Sum(int a, int b)
            {
                string aS = a.ToString();
                string bS = b.ToString();
                
                if (aS.Length != bS.Length)
                {
                    while(aS.Length < bS.Length)
                    {
                        aS = "0" + aS;
                    }

                    while (bS.Length < aS.Length)
                    {
                        bS = "0" + bS;
                    }
                }

                string result = string.Empty;
                int over = 0;
                Stack<int> stack = new Stack<int>();
                for(int i = aS.Length - 1; i > 0; i--)
                {
                    int tempRes = int.Parse(aS[i].ToString()) + int.Parse(bS[i].ToString());
                    if(stack.Count != 0)
                    {
                        tempRes += stack.Pop();
                    }
                    if (tempRes == 2)
                    {
                        over++;
                        result = "0" + result;
                        stack.Push(1);
                    } else
                    {
                        result = tempRes + result;
                    }
                }

                while (over >= 0)
                {
                    result = "0" + result;
                    over--;
                }

                return result;
            }
        }
    }
}
