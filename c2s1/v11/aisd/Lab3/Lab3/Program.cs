using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Collections.Generic;
using System;
static class Program
{
    static string Result = string.Empty;
    private class Node
    {

        public char? Value;


        public Node? Left, Right;

        public char VAL;
        public string Code = string.Empty;

        public Node(char value)
        {
            Value = value;
            VAL = value;
        }

        public void AddNeighbour(Node left, Node right)
        {
            Value = null;
            Left = left;
            Right = right;
        }

        public void AddToCode(string dir)
        {
            Code = dir + Code;
            Left?.AddToCode(dir);
            Right?.AddToCode(dir);
        }
    }



    private static void Main()
    {
        string n = Console.ReadLine();

        Dictionary<char, int> letters = new();

        for (int i = 0; i < n.Length; i++)
        {
            // Ищем уникальные символы
            if (!letters.ContainsKey(n[i]))
                // Добавляем в словарь, и считаем количество символов для приоритета
                letters.Add(n[i], n.Count(x => x == n[i]));
        }

        // отдельный словарь для сортированных узлов
        Dictionary<Node, int> sorted = new();
        foreach (var c in letters.OrderBy(k => k.Value))
        {
            sorted.Add(new Node(c.Key), c.Value);
        }
        
        /*
        foreach (var c in sorted)
        {
            Console.WriteLine(c.Key.Value + " " + c.Value);
        }
        */


        Dictionary<Node, int> saveNodes = new();

        if (sorted.Count == 1)
        {
            var s = sorted.First();

            s.Key.Code = "0";
            saveNodes.Add(s.Key, s.Value);
        }
        
        while (sorted.Count != 1)
        {
            // Выделяем минимальные узлы, сохраняем и удаляем их
            var left = MinBy(sorted);
            sorted.Remove(left.Key);
            var right = MinBy(sorted);
            sorted.Remove(right.Key);
            
            
            // временный узел
            var temp = new Node('t');
            temp.AddNeighbour(left.Key, right.Key);
            sorted.Add(temp, left.Value + right.Value);
            
            // установка поворота
            left.Key.AddToCode("1");
            right.Key.AddToCode("0");
            
            // если узел не корень
            if (left.Key.Value is not null)
            {
                saveNodes.Add(left.Key, left.Value);
            }
            
            if (right.Key.Value is not null)
            {
                saveNodes.Add(right.Key, right.Value);
            }
            
            // Снова сортируем по возрастанию
            sorted = SortByValue(sorted);
        }


        // хэш мап БУКВА - КОД
        Dictionary<char, string> map = new();
        foreach (var sn in saveNodes.OrderByDescending(x => x.Value))
        {
            map.Add(sn.Key.VAL,sn.Key.Code);
        }

        string res = String.Empty;
        foreach (var v in n)
        {
            // Конвертируем исходную строку в новую
            res += map[v];
        }
        
        // Вывод
        Console.WriteLine($"{letters.Count} {res.Length}");
        foreach (var sn in saveNodes.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{sn.Key.Value} : {sn.Key.Code}");
        }
        
        Console.WriteLine(res);
    }

    private static Dictionary<Node, int> SortByValue(Dictionary<Node, int> letters)
    {
        Dictionary<Node, int> sorted = new();
        foreach (var c in letters.OrderBy(k => k.Value))
        {
            sorted.Add(c.Key, c.Value);
        }

        return sorted;
    }
    
    private static KeyValuePair<Node, int> MinBy(Dictionary<Node, int> letters)
    {
        Dictionary<Node, int> sorted = new();
        foreach (var c in letters.OrderBy(k => k.Value))
        {
            return new KeyValuePair<Node, int>(c.Key, c.Value);
        }

        return new KeyValuePair<Node, int>();
    }
    
}