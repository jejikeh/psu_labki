using Microsoft.VisualBasic;
using System.Text;

string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

string Crypt(string input, string key, Dictionary<char, string> shift)
{
    var result = string.Empty;
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == ' ')
        {
            result += ' ';
            continue;
        }

        result += shift[key[i % key.Length]][alphabet.IndexOf(input[i])].ToString();
    }

    return result;
}

Dictionary<char, string> BuildShift(string input)
{
    var shift = new Dictionary<char, string>();
    for(var i = 0; i < input.Length; i++)
    {
        shift.Add(input[i], string.Empty);
        var shiftIndex = alphabet.IndexOf(input[i]);
        for(var j = 0; j < alphabet.Length; j++)
        {
            if (shiftIndex == alphabet.Length)
                shiftIndex = 0;

            shift[input[i]] = shift[input[i]] + alphabet[shiftIndex];
            shiftIndex++;
        }
    }

    return shift;
}

Dictionary<string, List<int>> RepeatedBlocks(string input)
{
    var repeatedMap = new Dictionary<string, List<int>>();
    for(var i = 0; i < input.Length - 3; i++)
    {
        string block = input.Substring(i, 3);
        if (!repeatedMap.ContainsKey(block))
            repeatedMap[block] = new List<int>();
        repeatedMap[block].Add(i);
    }

    return repeatedMap;
}

List<int> CalcKeyLengths(Dictionary<string, List<int>> repeatedMap)
{
    var keyLengths = new List<int>();
    foreach (var map in repeatedMap)
    {
        var positions = map.Value;
        for (var i = 0; i < positions.Count - 1; i++)
        {
            for (var j = i + 1; j < positions.Count; j++)
            {
                var distance = positions[j] - positions[i];
                if (distance > 0)
                    keyLengths.Add(distance);
            }
        }
    }

    return keyLengths;
}

var cryptedText = 
    Crypt(
        "DJEOIJOI JEOIDJEOIHFOJED EHFIOEJOIEHFOEJDOI JEDHOEIJDOEJDEHFEJDJNAONOEJDOAD ONEOIDOEDJ OAKEDNOEADNOIEDJ OEAHFOIJPAJOWKOPJPQOJDOQIJDOQNC IJDIJONEIODJAEOIDJOAEIHAOJCOEANOINEOI JDIOEJADOSOJ JDEOIJDALKJD JDJEIOJAFKLAJKEADJLK JELJADLKJAELKDJAEOIFJ AJPAPDJAFOIOIEJD", "HAVEIOPKCXZ", 
        BuildShift("HAVEIOPKCXZ"));
var lengths = CalcKeyLengths(RepeatedBlocks(cryptedText));

Console.WriteLine($"Crypted Text: {cryptedText}");
foreach(var length in lengths)
    Console.WriteLine($"Possible key length: {length}");