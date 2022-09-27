namespace Lab2.MachineCodes;

static class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        
        // число из десятичной системы счисления в двоично-десятичную
        Console.WriteLine(Converter.DecimalToBCD(945.0f));
        
        // число из двоично-десятичной системы счисления в десятичную.
        Converter.BSDtoDecimal(Converter.DecimalToBCD(444.125f));
        
        // Зашифруйте данный текст, используя таблицу ASCII-кодов
        var coded = Converter.TextToAscii(
            "Decoded Text. Lancev Evgeni Nikolaevich");
        Console.WriteLine(coded);
        
        // Дешифруйте данный текст, используя таблицу ASCII-кодов
        Console.WriteLine(Converter.AsciiToText(coded));
        
        // Представьте числа в прямом, обратном, дополнительном кодах
        Console.WriteLine(Converter.StraightCode(-945));
        Console.WriteLine(Converter.AdditionalCode(-945));
        Console.WriteLine(Converter.ReversedCode(-945));
        
        // Выполните сложение чисел в обратом и дополнительном кодах
        Console.WriteLine(Calculator.ReverseSum(399,309));
        Console.WriteLine(Calculator.AdditionalSum(399,309));
        
        // Представьте числа в нормализованном виде
        Console.WriteLine(Converter.Normalize(0.000945M));
        Console.WriteLine(Converter.Normalize(945000M));
        
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