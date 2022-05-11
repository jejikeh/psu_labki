using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19lab
{
    class IntClass
    {
        private int _value;
        private int? userInput;

        public int Value { get { return _value; } }

        public IntClass(int value)
        {
            _value = value;
        }
    }
    class Task2
    {
        private float ReturnMin(float x, float y)
        {
            return x <= y ? x : y;
        }
        private int ReturnMin(int x, int y)
        {
            return x <= y ? x : y;
        }
        private IntClass ReturnMin(IntClass x, IntClass y)
        {
            return x.Value <= y.Value ? x : y;
        }

        public void DrawTask()
        {
            Menu menu = new Menu();
            menu.DrawHeader("Task 2", ConsoleColor.Green);

            menu.DrawLine("Input a 1 number");
            menu.PrepareForInput(ConsoleColor.Green);
            int x = Convert.ToInt16(Console.ReadLine());
            menu.DrawLine("Input a 2 number");
            menu.PrepareForInput(ConsoleColor.Green);
            int y = Convert.ToInt16(Console.ReadLine());

            Tuple<IntClass, IntClass> xy = new Tuple<IntClass, IntClass>(new IntClass(x),new IntClass(y));

            menu.DrawOutput($"Min value of {xy.Item1.Value} and {xy.Item2.Value} is : {ReturnMin(xy.Item1,xy.Item2).Value}");

            menu.DrawEnd();
        }
    }
}
