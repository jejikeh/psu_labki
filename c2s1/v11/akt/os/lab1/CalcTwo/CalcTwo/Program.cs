using System.Globalization;
float CalculateFormula(float a) => MathF.Sqrt(a);

if (!File.Exists("output.txt"))
    throw new Exception("File doesnt exist");

await File.WriteAllTextAsync("output.txt", CalculateFormula(Convert.ToSingle(args[0], CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture));