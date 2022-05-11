namespace _22lab
{
    class Program
    {
        static void Main()
        {
            
            while(true)
            {
                Console.WriteLine("Input a number : ");
                try
                {
                    Console.WriteLine(new Program().CalculateExpressions(Convert.ToDouble(Console.ReadLine())));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                 
            }
        }

        public KeyValuePair<double, double> CalculateExpressions(double x)
        {
            if (x <= 0)
            {
                throw new Exception("Wrong input number");
            }
            else
            {
                return new KeyValuePair<double, double>(
                    Math.Sqrt(Math.Pow((3 * x + 2), 2) - (24 * x)) / (3 * Math.Sqrt(x) - (1 / 2 * Math.Sqrt(x))),
                    -Math.Sqrt(x)
                );
            }
        }
    }

    
}