string text = File.ReadAllText(@"C:\Users\jejik\Projects\university\labki\c2s1\v11\kpo\lab4.Files\lab4.Files\Template.txt");

var words = text.Split(" ");

string newText = string.Empty;
foreach(var word in words)
{
    bool num = false;
    foreach(var ch in word)
    {

        Console.WriteLine($"{ch} repeated " + text.Count(x => x == ch) + " times");

        int n = 0;
        if (int.TryParse(ch.ToString(),out n))
        {
            n++;
            num = true;
        }

    }
    if (!num)
    {
        newText += word + " ";
    }
}

await File.WriteAllTextAsync(@"C:\Users\jejik\Projects\university\labki\c2s1\v11\kpo\lab4.Files\lab4.Files\Template.txt", newText);


