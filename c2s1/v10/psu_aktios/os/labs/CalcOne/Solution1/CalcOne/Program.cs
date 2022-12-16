using System.Diagnostics;
using System.Globalization;

float CalculateFormula(float a, float b, float c) => MathF.Sqrt(a +b ) / c;

var sourceText = File.ReadAllText("D:/2course/psu_aktios/os/labs/source.txt").Split(' ').Select(x => Convert.ToSingle(x, CultureInfo.InvariantCulture)).ToArray();

Process.Start("D:/2course/psu_aktios/os/labs/CalcTwo/CalcTwo/bin/Debug/net7.0/CalcTwo.exe", $"{CalculateFormula(sourceText[0],sourceText[1], sourceText[2]).ToString(CultureInfo.InvariantCulture)}");