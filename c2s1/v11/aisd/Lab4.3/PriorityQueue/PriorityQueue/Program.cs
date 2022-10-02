using System;
using System.Collections;

public class MainClass
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var commandCount = int.Parse(input);
        
        PriorityQueue<int> queue = new PriorityQueue<int>();
        for(int i=0; i<commandCount; i++)
        {
            var commands = Console.ReadLine()!.Split(' ');
            switch(commands[0])
            {
                case "Insert": 
                    {
                        var value = int.Parse(commands[1]);
                        queue.Add(value, value); break;
                    }
                case "ExtractMax": Console.WriteLine(queue.Poll()); break;
            }
        }
    }
    
    class PriorityQueue<T>
    {
        struct Item<T>
        {
            public T value;
            public int priority;
            
            public Item(T value, int priority)
            {
                this.value = value;
                this.priority = priority;
            }
            
            public bool Compare(Item<T> item)
            {
                return priority > item.priority;
            }
        }
        
        static ArrayList items = new ArrayList();
        
        private void BinAdd(Item<T> item)
        {            
            int i = -1;
            int j = items.Count;
            int avr;
            while(i + 1 < j)
            {
                avr = (i + j) >> 1;
                if(item.Compare((Item<T>)items[avr])) {
                    j = avr; 
                }
                else i = avr;
            }
            items.Insert(++i, item);
        }

        // Return the number of items in the queue.
        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        // Add an item to the queue.
        public void Add(T new_value, int new_priority)
        {
            BinAdd(new Item<T>(new_value, new_priority));
        }

        // Remove the item with the largest priority from the queue.
        public T Poll()
        {
            Item<T> top_item = (Item<T>)items[0]; 
            items.Remove(top_item);
            return top_item.value;
        }
    }
}