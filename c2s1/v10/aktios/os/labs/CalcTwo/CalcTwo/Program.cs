using System.Globalization;
float CalculateFormula(float a) => MathF.Pow(a,6);

if (!File.Exists("D:/2course/psu_aktios/os/labs/output.txt"))
{ 
    throw new Exception("File doesnt exist"); 
}
    await File.WriteAllTextAsync("D:/2course/psu_aktios/os/labs/output.txt", CalculateFormula(Convert.ToSingle(args[0], CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture));

