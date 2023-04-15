using System.Text;
using System.Text.Unicode;
using Lab6;

var idea = new Idea("12345678soidfhiuoshf iuhfiulhsjfsioejdo isejfhoishfjiosjfoi shfos ", true);
var crypt = idea.Crypt("Fuck you Fuck you Fuck you Fuck youFuck you Fuck you Fuck you Fuck you Fuck you Fuck you"u8.ToArray());

Console.WriteLine(Encoding.ASCII.GetString(crypt));