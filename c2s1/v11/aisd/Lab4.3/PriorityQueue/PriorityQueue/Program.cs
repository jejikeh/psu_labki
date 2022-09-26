static class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] quene = new int[n];
        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split(' ');
            switch (command[0])
            {
                case "Insert":
                    int d = int.Parse(command[1]);
                    quene.Sort;
                    break;
                case "ExtractMax":
                    Console.WriteLine(quene.Last());
                    quene.RemoveAt(quene.Count - 1);
                    break;
            }
        }
    }
}