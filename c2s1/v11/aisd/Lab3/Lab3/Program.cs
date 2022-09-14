using System.Net;
using System.Security.Cryptography.X509Certificates;

static class Program
{
    static string Result = string.Empty;
    private class Node
    {

        public char Value;

        public int Freq = 0;

        public Node? Left, Right = null;

        public string Code = string.Empty;
        public Node(char value, int freq, Node? left = null, Node? right = null, bool sort = true)
        {
            Value = value;
            Freq = freq;
            Left = left;
            Right = right;
            if (sort)
            {
                Left?.AddToCode(Code + "1");
                Right?.AddToCode(Code + "0");
            }
        }

        public void AddToCode(string direction)
        {
            Code += direction;
            if(Left is null || Right is null)
            {
                Result += Code;
            }
        }
    }

    private static void Main()
    {
        string n = Console.ReadLine();

        Dictionary<char, int> letters = new();

        for(int i = 0; i < n.Length; i++)
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
            sorted.Add(new Node(c.Key, c.Value), c.Value);
        }

        foreach(var c in sorted)
        {
            Console.WriteLine(c.Key.Value + " " + c.Value);
        }


        while(sorted.Count != 1)
        {
            // Выделяем минимальные узлы, сохраняем и удаляем их
            var minFirst = sorted.MinBy(x => x.Value);
            sorted.Remove(minFirst.Key);
            var minSecond = sorted.MinBy(x => x.Value);
            sorted.Remove(minSecond.Key);

            // Добавляем обратно, считая новый приоритет.
            sorted.Add(new Node(' ',minFirst.Value + minSecond.Value, minFirst.Key, minSecond.Key), minFirst.Value + minSecond.Value);

            // Снова сортируем по возрастанию
            sorted = SortByValue(sorted);
        }
    }

    private static Dictionary<Node, int> SortByValue(Dictionary<Node, int> letters)
    {
        Dictionary<Node, int> sorted = new();
        foreach (var c in letters.OrderBy(k => k.Value))
        {
            sorted.Add(new Node(c.Key.Value, c.Value, c.Key.Left, c.Key.Right, false), c.Value);
        }

        return sorted;
    }
}