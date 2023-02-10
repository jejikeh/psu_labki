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
        string n = File.ReadAllText("../../../save.json");

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

            var temp = new Node('t');
            temp.AddNeighbour(left.Key, right.Key);
            sorted.Add(temp, left.Value + right.Value);
            
            left.Key.AddToCode("1");
            right.Key.AddToCode("0");

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



        Dictionary<char, string> map = new();
        foreach (var sn in saveNodes.OrderByDescending(x => x.Value))
        {
            map.Add(sn.Key.VAL,sn.Key.Code);
        }

        string res = String.Empty;
        foreach (var v in n)
        {
            res += map[v];
        }
        Console.WriteLine($"Symbol\tCode\tLength");
        foreach (var sn in saveNodes.OrderByDescending(x => x.Value))
            Console.WriteLine($"{sn.Key.Value}\t{sn.Key.Code}\t{sn.Key.Code.Length}");
        
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