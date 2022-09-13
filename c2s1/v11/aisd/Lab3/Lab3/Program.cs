using System.Net;
using System.Security.Cryptography.X509Certificates;

static class Program
{
    private class Node
    {
        public List<object> Childs = new List<object>();

        public char Value;

        public int P = 0;
        public Node(params object[] nodes)
        {
            Childs.AddRange(nodes);
            foreach(var ob in nodes.Where(x => x is KeyValuePair<char, int>))
            {
                KeyValuePair<char, int> cobj = (KeyValuePair<char, int>)ob;
                P += cobj.Value;
            }

            foreach (var ob in nodes.Where(x => x is Node))
            {
                Node cobj = (Node)ob;
            }
        }

    }
    private static void Main()
    {
        string n = Console.ReadLine();

        Dictionary<char, int> letters = new();

        for(int i = 0; i < n.Length; i++)
        {
            if (!letters.ContainsKey(n[i]))
                letters.Add(n[i], n.Count(x => x == n[i]));
        }


        List<object> list = new();
        Dictionary<object, int> sorted = new();
        foreach (var c in letters.OrderBy(k => k.Value))
        {
            sorted.Add(c.Key,c.Value);
        }
    }
}