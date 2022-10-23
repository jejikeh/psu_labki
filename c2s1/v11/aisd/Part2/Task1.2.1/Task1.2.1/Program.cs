using System;
using System.Collections.Generic;
using System.Linq;

var dict = new Dictionary<char, char>()
{ { '(', ')' }, { '{', '}' }, { '[', ']' } };

var input = Console.ReadLine()!.ToList();
var stack = new Stack<Tuple<char,int>>();
Console.WriteLine(CheckBrackets(input));
string CheckBrackets(IReadOnlyList<char> inputString)
{
    for (var i = 0; i < inputString.Count; i++)
    {
        if (dict.ContainsKey(inputString[i]))
            stack.Push(new Tuple<char, int>(inputString[i], i + 1));
        else if (dict.ContainsValue(inputString[i]))
            // if stack is empty or not correct bracket
            if (!stack.Any() || dict[stack.Pop().Item1] != inputString[i])
                return (i + 1).ToString();
    }
    // if stack is empty when success
    return stack.Any() ? stack.Pop().Item2.ToString() : "Success";
}