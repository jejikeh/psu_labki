using System.Diagnostics;
using System.Globalization;

float CalculateFormula(float a, float b, float c) => MathF.Sqrt(a * b * c) / MathF.Log2(a);

var sourceText = File.ReadAllText("source.txt").Split(' ').Select(x => Convert.ToSingle(x, CultureInfo.InvariantCulture)).ToArray();


Process.Start("../../../../../CalcTwo/CalcTwo/bin/Debug/net6.0/CalcTwo.exe" ,$"{CalculateFormula(sourceText[0],sourceText[1], sourceText[2]).ToString(CultureInfo.InvariantCulture)}");


