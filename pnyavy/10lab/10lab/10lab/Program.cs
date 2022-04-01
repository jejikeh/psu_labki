class Program {
    static void Main() {
        Staff[] staffArray = new Staff[4];

        for(int i = 0; i < 4;i++)
        {
            Console.WriteLine("Name -> ");
            string name = Console.ReadLine();
            Console.WriteLine("Numver -> ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Rank -> ");
            int rank = Convert.ToInt32(Console.ReadLine());
            staffArray[i] = new Staff(name,number,rank);

        }

        for (int i = 0; i < 4; i++)
        {
            staffArray[i].Print();
        }

    }
}