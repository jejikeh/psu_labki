namespace CoverSegmentsWithDots;

static class Program
{
    static List<int> Dots(List<Tuple<int, int>> segments)
    {
        List<Tuple<int, int>> res_segments = new List<Tuple<int, int>>();
        while (segments.Count > 0)
        {
            if (segments.Count < 2)
            {
                res_segments.Add(segments.Last());
                segments.RemoveAt(segments.Count - 1);
            }
            else
            {
                Tuple<int, int> a = segments[0], b = segments[1];
                if (b.Item1 <= a.Item2)
                {
                    var left = b.Item1;
                    var right = b.Item2 <= a.Item2 ? b.Item2 : a.Item2;
                    Tuple<int,int> overlapping = new Tuple<int, int>(left, right);
                    segments = segments.GetRange(2, segments.Count - 2);
                    segments.Insert(0, overlapping);

                }
                else
                {
                    res_segments.Add(segments[0]);
                    segments = segments.GetRange(1, segments.Count - 1);
                }
            }
        }

        List<int> result = new List<int>();
        foreach (var x in res_segments)
        {
            result.Add(x.Item2);
        }

        return result;
    }
    
    static void Main()
    {
        List<Tuple<int, int>> segments = new List<Tuple<int, int>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] segment = Console.ReadLine().Split(' ');
            segments.Add(new Tuple<int, int>(int.Parse(segment[0]), int.Parse(segment[1])));
        }

        segments = segments.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
        var result = Dots(segments);
        
        Console.WriteLine(result.Count);
        result.ForEach(x =>
        {
            Console.Write(x + " ");
        });
    }
}