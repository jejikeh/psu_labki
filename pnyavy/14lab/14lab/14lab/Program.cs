namespace _14lab
{

    class Program
    {
        static private void Main()
        {
            Console.WriteLine("Input max size of array : ");
            VectorArray vectorArray = new VectorArray(Convert.ToInt16(Console.ReadLine())); // Создание массива

            for(int i = 0; i < vectorArray.GetMaxValue; i++)
            {
                Console.WriteLine("Input value of " + i + " element : ");
                vectorArray.Add(Convert.ToInt16(Console.ReadLine()));
            }
            Console.WriteLine("Root : ");
            Console.WriteLine(vectorArray.Root()?.GetValue); // Вывод корневого

            Console.WriteLine("Check equal : ");
            vectorArray.CheckEqual();

            Console.WriteLine("Add 1 to all : ");
            vectorArray.AddValueToAll(1);
            vectorArray.Print();
        }
    }
}
