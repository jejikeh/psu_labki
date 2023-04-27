using System.Text;
using Lab6;

var inputText = File.ReadAllText("../../../Idea.cs");

var key = Idea.CreateRandomKey(16);
var ideaCrypt = new Idea(key, true);
var encoded = ideaCrypt.Crypt(inputText.Select(x => (byte)x).ToArray()); 
Console.WriteLine(Encoding.ASCII.GetString(encoded.ToArray()));

Console.WriteLine("--------------");

var ideaDecrypt = new Idea(key, false);
var decoded = ideaDecrypt.Crypt(encoded);
Console.WriteLine(Encoding.ASCII.GetString(decoded.ToArray()));