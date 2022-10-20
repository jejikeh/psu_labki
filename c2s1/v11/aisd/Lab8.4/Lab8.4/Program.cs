var count = int.Parse(Console.ReadLine().Split(' ')[0]);
var items = new List<int>();

var elements = Console.ReadLine();

foreach (var item in elements.Split(' '))
    items.Add(int.Parse(item));

var result = int.MinValue;
for (var i = 0; i < items.Count; i++)
{
    var resOfNumber = items[i];
    for (var k = 0; k < items.Count; k++)
    {
        if( i == k)
            continue;

        if (resOfNumber + items[k] <= count)
            resOfNumber += items[k];
    }

    if (resOfNumber > result && resOfNumber <= count)
        result = resOfNumber;
}

Console.WriteLine(result);