namespace Lab2.MachineCodes;

static class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Console.WriteLine("Task1");
        // число из десятичной системы счисления в двоично-десятичную
        Console.WriteLine(Converter.DecimalToBCD(945.0f));
        
        Console.WriteLine("Task2");
        // число из двоично-десятичной системы счисления в десятичную.
        Console.WriteLine(Converter.BSDtoDecimal(Converter.DecimalToBCD(444.125f)));
        
        Console.WriteLine("Task3");
        // Зашифруйте данный текст, используя таблицу ASCII-кодов
        var coded = Converter.TextToAscii(
            "Decoded Text. Lancev Evgeni Nikolaevich");
        Console.WriteLine(coded);
        
        Console.WriteLine("Task4");
        // Дешифруйте данный текст, используя таблицу ASCII-кодов
        Console.WriteLine(Converter.AsciiToText(coded));
        
        
        Console.WriteLine("Task5");
        // Представьте числа в прямом, обратном, дополнительном кодах
        Console.WriteLine(Converter.StraightCode(-15));
        Console.WriteLine(Converter.AdditionalCode(-945));
        Console.WriteLine(Converter.ReversedCode(-15, 8));
        
        
        Console.WriteLine("Task6");
        // Выполните сложение чисел в обратом и дополнительном кодах
        Console.WriteLine(Calculator.ReverseSum(-34,-15));
        Console.WriteLine(Calculator.AdditionalSum(399,309));
        
        Console.WriteLine("Task7");
        // Представьте числа в нормализованном виде
        Console.WriteLine(Converter.Normalize(0.000945M));
        Console.WriteLine(Converter.Normalize(945000M));
        
        Console.WriteLine("Task8");
        // Выполните четыре арифметических действия над числами в формате с плавающей точкой
        Console.WriteLine(Calculator.NormilizeSum(
            Converter.Normalize(541000M),
            Converter.Normalize(0.00322M)));
        
        Console.WriteLine(Calculator.NormilizeSubstract(
            Converter.Normalize(7670000M),
            Converter.Normalize(17700M)));
        
        Console.WriteLine(Calculator.NormilizeMutliply(
            Converter.Normalize(58000M),
            Converter.Normalize(0.0096M)));
        
        Console.WriteLine(Calculator.NormilizeDevide(
            Converter.Normalize(74.1875M),
            Converter.Normalize(15.3125M)));
    }
}