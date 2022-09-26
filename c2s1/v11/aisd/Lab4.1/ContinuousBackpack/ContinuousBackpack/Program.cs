namespace ContinuousBackpack
{
    static class Program
    {
        struct Item
        {
            public double Value;
            public double Volume;
            public double ValuePerVolume;

            public Item(string[] input)
            {
                Value = double.Parse(input[0]);
                Volume = double.Parse(input[1]);
                ValuePerVolume = Value / Volume;
            }
        }
        
        class Backpack
        {
            public double Capacity;
            private double _value = 0;

            public Backpack(string capacity)
            {
                Capacity = double.Parse(capacity);
            }

            public double CalculateValue(List<Item> items)
            {
                while (items.Count > 0)
                {
                    if (Capacity > 0)
                    {
                        if (Capacity >= items[0].Volume)
                        {
                            _value += items[0].Value;
                            Capacity -= items[0].Volume;
                        }
                        else
                        {
                            _value += Capacity * items[0].ValuePerVolume;
                            break;
                        }
                    }
                    items = items.GetRange(1, items.Count - 1);
                }

                return _value;
            }
        }
        
        static void Main()
        {
            string[] backpackInput = Console.ReadLine().Split(' ');
            List<Item> items = new List<Item>();
            
            Backpack backpack = new Backpack(backpackInput[1]);
            for (int i = 0; i < int.Parse(backpackInput[0]); i++)
            {
                items.Add(new Item(Console.ReadLine().Split(' ')));
            }

            items = items.OrderByDescending(x => x.ValuePerVolume).ToList();
            Console.WriteLine($"{backpack.CalculateValue(items):F3}");
        }
    }
}