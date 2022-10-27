var list = Console.ReadLine()!.Split(' ', ',')
    .Where(x => x != string.Empty && x.All(char.IsDigit))
    .Select(int.Parse);

foreach (var i in list)
    Console.WriteLine(i);