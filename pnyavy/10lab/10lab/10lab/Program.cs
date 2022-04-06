class Program {
    static void Main() {
        Staff[] staffArray = new Staff[4];

        for(int i = 0; i < 4;i++)
        {
            Console.WriteLine("Name -> ");
            string? name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Number -> ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Rank -> ");
            int rank = Convert.ToInt32(Console.ReadLine());
            if(name != null)
            {
                staffArray[i] = new Staff(name,number,rank);
            }

        }

        for (int i = 0; i < 4; i++)
        {
            staffArray[i].Print();
        }

    }
}