using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19lab
{
    class Menu
    {
        public void DrawMenu()
        {
            DrawHeader("Menu", ConsoleColor.Green);
            DrawLine("1. Task 1");
            DrawLine("2. Task 2");
            DrawLine("3. Task 3");

        }

        public void PrepareForInput(ConsoleColor color = ConsoleColor.White)
        {
            Console.Write("\n\n");
            Console.ForegroundColor = color;
            //Console.Write(":::::: ");
            Console.Write($"\tInput : ");
            Console.ResetColor();
        }

        public void DrawError(string c, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.Write("\nError : ");
            Console.Write($"{c}");
            Console.ResetColor();
            Console.Write("\n");
        }

        public void DrawOutput(string c,string output = "Output", ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n{output} : ");
            Console.ForegroundColor = color;
            Console.Write($"{c}");
            Console.ResetColor();
            Console.Write("\n");
        }

        public void DrawHeader(string c, ConsoleColor color = ConsoleColor.White)
        {
            Console.Write("\n::::::");
            Console.ForegroundColor = color;
            Console.Write($"\t\t{c}\t\t");
            Console.ResetColor();
            Console.Write("::::::\n");
        }

        public void DrawLine(string c, ConsoleColor color = ConsoleColor.White)
        {
            Console.Write("\n");
            Console.ForegroundColor = color;
            Console.Write($"\t{c}");
            Console.ResetColor();
        }

        public void DrawEnd(ConsoleColor color = ConsoleColor.Yellow)
        {
            DrawLine("\nPress enter...\n", color);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
