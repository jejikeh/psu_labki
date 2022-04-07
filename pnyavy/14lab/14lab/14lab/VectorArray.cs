
namespace _14lab
{
    class Node
    {
        private int Value;
        private int Index;

        public Node(int value, int index)
        {
            Value = value;
            Index = index;
        }
        internal void Print()
        {
            Console.WriteLine("Value -> " + Value + " at " + Index + " index");
        }

        internal void Add(int value)
        {
            Value = Value + value;
        }
    }

    
    class VectorArray
    {
        public int CurrentSize = -1;
        public Node[] Array;

        public VectorArray(int maxSizeArray)
        {
            Array = new Node[maxSizeArray];
        }

        public void Add(int value)
        {
            CurrentSize++;
            Array[CurrentSize] = new Node(value, CurrentSize);
        }

        public void Print()
        {
            for(int i = 0; i <= CurrentSize; i++)
            {
                Array[i].Print();
            }
        }

        public void AddValueToAll(int value)
        {
            for (int i = 0; i <= CurrentSize; i++)
            {
                Array[i].Add(value);
            }
        }
    }
}
