Console.ReadLine();

var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToList();
Console.WriteLine(CountDepth(input));

int CountDepth(List<int> depths)
{
    return depths.Select(index => GetHeight(depths, index)).Max();
}

int GetHeight(List<int> depths,int index)
{
    return depths[index] != -1 ? GetHeight(depths, depths[index]) : 1;
}