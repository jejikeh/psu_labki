using System.Diagnostics;
using System.Globalization;

float CalculateFormula(float a, float b, float c) => MathF.Sqrt(a +b ) / c;
var sourceText = File.ReadAllText("source.txt").Split(' ').Select(x => Convert.ToSingle(x, CultureInfo.InvariantCulture)).ToArray();


Process.Start("../../../../../CalcOne/Solution1/CalcOne/bin/Debug/net7.0/CalcOne.exe" ,$"{CalculateFormula(sourceText[0],sourceText[1], sourceText[2]).ToString(CultureInfo.InvariantCulture)}");