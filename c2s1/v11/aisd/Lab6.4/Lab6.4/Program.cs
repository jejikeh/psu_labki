var inputN = int.Parse(Console.ReadLine()!);
var inputString = Console.ReadLine()!.Split(' ');


var result = 0;
for (var i = 0; i < inputN; i++)
{
    for (var j = i; j < inputN; j++)
    {
        if (int.Parse(inputString[i]) > int.Parse(inputString[j]))
            result++;
    }
}

Console.WriteLine(result);