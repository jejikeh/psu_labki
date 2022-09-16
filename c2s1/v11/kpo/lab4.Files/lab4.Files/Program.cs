string text = File.ReadAllText(@"../../../Template.txt");

var words = text.Split(" ");

string newText = string.Empty;
foreach(var word in words)
{
    bool num = false;
    foreach(var ch in word)
    {

        Console.WriteLine($"{ch} repeated " + text.Count(x => x == ch) + " times");

        int _ = 0;
        if (int.TryParse(ch.ToString(),out _))
        {
            num = true;
        }

    }
    if (!num)
    {
        newText += word + " ";
    }
}

await File.WriteAllTextAsync(@"../../../Template.txt", newText);


