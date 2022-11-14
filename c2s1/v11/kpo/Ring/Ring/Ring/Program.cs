using System.Collections;

namespace Ring
{
    internal interface IRingNode
    {
        public int Length { get; }

        public IRingNode? NextNode { get; set; }
    }
    
    internal class OneConnectedRing<T> : IEnumerable<T> where T : IRingNode
    {
        private List<T> _ring = new List<T>();

        public T this[int index] => _ring[index];

        public IEnumerator<T> GetEnumerator()
        {
            return _ring.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T node)
        {
            var lastNode = _ring.Count > 0 ? _ring.Last() : node;
            var firstNode = _ring.Count > 0 ? _ring.First() : node;
            node.NextNode = firstNode;
            lastNode.NextNode = node;
            _ring.Add(node);
        }

        public T Min()
        {
            return _ring.MinBy(x => x.Length);
        }

        public void ReplaceWithNextNode(T node)
        {
            var nextNode = node.NextNode ?? node;
            nextNode.NextNode = node;
            var previousNode = _ring.Find(x => x.NextNode == (IRingNode?)node) ?? node;
            previousNode.NextNode = nextNode;
            Remove(node);
        }

        public bool Remove(T node)
        {
            return _ring.Remove(node);
        }
    }
    
    internal class RingNode<T> : IRingNode
    {
        private readonly Stack<T> _storedData;
        public RingNode(Stack<T> storedData)
        {
            _storedData = storedData;
        }

        public Stack<T> StoredStack => _storedData;
        public int Length => _storedData.Count;
        public IRingNode? NextNode { get; set; }
    }

    internal static class Program
    {
        private static void Main()
        {
            var group1 = new Stack<string>();
            group1.Push("Gryadkin");
            group1.Push("Pyatkin");
            group1.Push("Xyatkin");
            
            var group2 = new Stack<string>();
            group2.Push("Tvar`kin");
            group2.Push("Mamkin");
            
            var group3 = new Stack<string>();
            group3.Push("Popkin");
            group3.Push("Mraz`kin");
            group3.Push("Pipkin");
            group3.Push("Pipkin");

            var ring = new OneConnectedRing<RingNode<string>>();
            ring.Add(new RingNode<string>(group1));
            ring.Add(new RingNode<string>(group2));
            ring.Add(new RingNode<string>(group3));

            foreach (var node in ring)
            {
                Console.WriteLine(node.Length);
                foreach (var data in node.StoredStack)
                {
                    Console.WriteLine($"\t {data}");
                }
            }
            
            ring.ReplaceWithNextNode(ring.Min());
            
            Console.WriteLine("--------");
            
            foreach (var node in ring)
            {
                Console.WriteLine(node.Length);
                foreach (var data in node.StoredStack)
                {
                    Console.WriteLine($"\t {data}");
                }
            }
        }
    }
}