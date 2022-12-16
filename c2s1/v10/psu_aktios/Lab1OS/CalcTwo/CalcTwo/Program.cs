using System.Globalization;
float CalculateFormula(float a) => MathF.Pow(a,6);

if (!File.Exists("output.txt"))
    throw new Exception("File doesnt exist");

await File.WriteAllTextAsync("output.txt", CalculateFormula(Convert.ToSingle(args[0], CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture));
