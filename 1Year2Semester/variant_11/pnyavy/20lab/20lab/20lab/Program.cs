namespace _20lab
{

    class Node
    {
        internal int value;

        public Node(int value)
        {
            this.value = value;
        }
    }

    abstract class StackTemplate // Шаблон класса
    {
        protected List<Node> Nodes = new List<Node> ();

        public void Add(int value)
        {
            Nodes.Insert(0, new Node(value));
        }
        public void Print() // Вывод стека
        {
            foreach (Node node in Nodes)
            {
                Console.WriteLine($"{node.value} ");
            }
        }
        ~StackTemplate() // Деструктор 
        {
            Console.WriteLine($"{Nodes.Count} has deleted");
        }

        public static bool operator !=(StackTemplate a,StackTemplate nodes)
        {
            a = nodes;
            return true;
        }
        public static bool operator ==(StackTemplate a, StackTemplate nodes)
        {
            a.Nodes = new List<Node>(nodes.Nodes);
            return true;
        }
    }

    class Stack : StackTemplate
    {
        public Stack(List<Node> nodes)
        {
            Nodes = new List<Node>(nodes);
        }
        public static Stack operator +(Stack stack, int value)
        {
            stack.Nodes.Add(new Node(value));
            return stack;
        }
        public static int operator -(Stack stack, int index)
        {
            Node f = stack.Nodes[index];
            stack.Nodes.RemoveAt(index);
            return f.value;
        }

        public static implicit operator bool(Stack stack)
        {
            return stack.Nodes.Count != 0;
        }
    }


    class Program
    { 
        static void Main()
        {
            
            Stack stack = new Stack(new List<Node>() { new Node(2), new Node(4) });

            _ = (stack + 3);

            stack.Print();
            Console.WriteLine($"First element - { stack - 0}");

            if (stack)
            {
                Console.WriteLine("stack is not empty");
            }else
            {
                Console.WriteLine("stack is empty");
            }

            Stack newStack = new Stack(new List<Node>() { new Node(20), new Node(40) });
            _ = stack==newStack;

            stack.Print();

        }

    }
}