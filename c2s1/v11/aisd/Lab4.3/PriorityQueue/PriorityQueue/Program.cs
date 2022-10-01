using System.Runtime.InteropServices;
using System.Security.AccessControl;

static class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var quene = new List<int>();
        var index = 0;
        
        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split(' ');
            switch (command[0])
            {
                case "Insert":
                    int d = int.Parse(command[1]);
                    quene.Add(d);
                    
                    break;
                case "ExtractMax":
                    Console.WriteLine(quene[^1]);
                    quene = quene.GetRange(0, quene.Count - 2);
                    break;
            }
        }
    }
}