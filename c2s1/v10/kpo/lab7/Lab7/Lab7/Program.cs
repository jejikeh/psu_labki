static class Program
{
    static int Task1()
    {
        int[] mas = new int[15];
        Random rand = new Random();
        for (int i = 0; i < 15; i++)
        {
            mas[i] = rand.Next(-10, 30);
            Console.Write(mas[i]+" ");
        }

        int c = 0;
        int sum = 0;
        for (int i = 0; i < 15; i++)
        {
            if (mas[i] > 0)
            {
                sum += mas[i];
                c++;
            }
        }
        int r = sum /c;
        Console.WriteLine("Среднее арифметическое: " + r);
        return Main();
    }

    static int Task2()
    {
        Console.WriteLine("Enter the number of items ");
        uint n = Convert.ToUInt32(Console.ReadLine());
        double[] mas = new double[n];
        double[] nmas = new double[n];
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            mas[i] = rand.NextDouble()+rand.Next(100);
            Console.Write(mas[i]+" ");
        }
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            nmas[i] = mas[i] * 0.5;
            Console.WriteLine(mas[i]+" "+nmas[i]);
        }
        Console.WriteLine();
        return Main();
    }

    static int Task3()
    {
        Console.WriteLine("Enter the number of lines: ");
        uint r = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine("Enter the number of columns: ");
        uint c = Convert.ToUInt32(Console.ReadLine());
        int[,] mas = new int[r, c];
        Random rand = new Random();
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                mas[i,j] = rand.Next(-100, 100);
                Console.Write(mas[i,j]+" ");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (mas[i, j] > 0)
                {
                    mas[i, j] = 1;
                }
                else
                {
                    mas[i, j] = 0;
                }
                Console.Write(mas[i,j]+" ");
            }
            Console.WriteLine();
        }

        return Main();
    }

    static int Task4()
    {
        int[,] mas = new int[4, 6];
        Random rand = new Random();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                mas[i,j] = rand.Next(30, 75);
                Console.Write(mas[i,j]+" ");
            }
            Console.WriteLine();
        }
        for (int j = 0; j < 6; j++)
        {
            int sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += mas[i, j];
            }
            Console.Write(sum/4 + " ");
            Console.WriteLine();
        }
        return Main();
    }
    static int Main()
    {
       Console.WriteLine("Choose task: ");
       int t = Convert.ToByte(Console.ReadLine());
       switch (t)
       {
         case 1:
             Task1();
             break;
         case 2:
             Task2();
             break;
         case 3:
             Task3();
             break;
         case 4:
             Task4();
             break;
         case 0:
             Console.WriteLine("Выход из программы...");
             break;
         default:
             Console.WriteLine("Неверный номер задания...");
             return Main();
             break;
       }
       return 0;
       
    }
}