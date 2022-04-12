namespace _16lab
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Input max size of array : ");
            VectorArray vectorArray = new VectorArray(Convert.ToInt16(Console.ReadLine())); // Создание массива

            for (int i = 0; i < vectorArray.GetMaxSize; i++)
            {
                Console.WriteLine("Input value of " + i + " element : ");
                vectorArray.Add(Convert.ToInt16(Console.ReadLine()));
            }

            Console.WriteLine("Root : ");
            vectorArray.PrintNode(vectorArray.Root()); // Вывод корневого

            Console.WriteLine("Input index of Element");
            vectorArray.PrintByIndex(Convert.ToInt16(Console.ReadLine()));

            Console.WriteLine("Add 1 to all : ");
            vectorArray.AddValueToAll(1);
            vectorArray.PrintAll();

            Console.WriteLine("Check equal : ");
            vectorArray.CheckEqual();

        }
    }
}
