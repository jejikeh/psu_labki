using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19lab
{
    class Vector
    {
        public List<int> Nodes = new List<int>();

        public Vector(List<int> values)
        {
            new Menu().DrawOutput("Vector created!");
            Nodes = new List<int>(values);
        }
        public Vector(int value)
        {
            Nodes.Add(value);
        }

        ~Vector()
        {
            new Menu().DrawOutput("Node deleted");
        }
    }

    class Matrix
    {
        public List<List<int>> Nodes = new List<List<int>>();

        public Matrix(List<List<int>> matrix)
        {
            new Menu().DrawOutput("Matrix created!");
            Nodes = new List<List<int>>(matrix);
        }


        ~Matrix()
        {
            new Menu().DrawOutput("Matrix deleted");
        }

        internal Matrix MultiplyByVector(Vector vector)
        {
            for(int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes[i].Count; j++)
                {
                    foreach(int k in vector.Nodes)
                    {
                        Nodes[i][j] *= k; 
                    }
                }
            }
            return this;
        }
    }

    class Task3
    {
        public void DrawTask()
        {
            Menu menu = new Menu();
            menu.DrawHeader("Task 3", ConsoleColor.Green);

            menu.DrawLine("Input length of Vector");
            menu.PrepareForInput(ConsoleColor.Green);
            int vectorLength = Convert.ToInt16(Console.ReadLine());
            List<int> vec = new List<int>();

            for(int i = 0; i < vectorLength; i++)
            {
                menu.DrawLine($"Input a {i} node of vector");
                menu.PrepareForInput(ConsoleColor.Green);
                vec.Add(Convert.ToInt16(Console.ReadLine()));
            }

            Vector vector = new Vector(vec);


            menu.DrawLine("Input number of columns of matrix");
            menu.PrepareForInput(ConsoleColor.Green);
            vectorLength = Convert.ToInt16(Console.ReadLine());
            menu.DrawLine("Input number of rows of matrix");
            menu.PrepareForInput(ConsoleColor.Green);
            int columnLength = Convert.ToInt16(Console.ReadLine());

            List<List<int>> vec2 = new List<List<int>>();
            Console.Clear();
            menu.DrawLine($"Fill matrix");
            for (int i = 0; i < columnLength; i++)
            {
                List<int> vv = new List<int>();
                for (int j = 0; j < vectorLength; j++)
                {
                    //menu.PrepareForInput(ConsoleColor.Green);
                    Console.SetCursorPosition((j*2) + 2, i + 3);
                    vv.Add(Convert.ToInt16(Console.ReadLine()));
                }
                vec2.Add(vv);
            }

            Matrix matrix = new Matrix(vec2).MultiplyByVector(vector);
            
            menu.DrawLine($"Matrix X Vector : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n");
            for (int i = 0; i < vec2.Count; i++)
            {
                for(int j = 0; j < vec2[i].Count; j++)
                {
                    Console.Write($"{ vec2[i][j]} ");
                }
                Console.Write($"\n");
            }
            Console.ResetColor();

            menu.DrawEnd();

        }
    }
}
