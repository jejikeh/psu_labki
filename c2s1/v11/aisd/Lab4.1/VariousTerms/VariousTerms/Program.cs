
static class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> k = new List<int>();

        int i = 1;
        int sum = 0;
        while (sum < n)
        {
            k.Add(i);
            sum += i;
            if (sum > n)
            {
                sum -= k.Last();
                k.RemoveAt(k.Count - 1);
                while (sum != n)
                {
                    sum -= k[k.Count - 1];
                    k[k.Count - 1] = k[k.Count - 1] + 1;
                    sum += k[k.Count - 1];
                }
            }

            i++;
        }

        Console.WriteLine(k.Count);
        k.ForEach(x =>
        {
            Console.Write($"{x} ");
        });
    }
}