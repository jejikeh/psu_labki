using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab11
{
    public partial class Form1 : Form
    {
        internal interface IRingNode
        {
             int Length { get; }

             IRingNode NextNode { get; set; }
             Stack Data();
             void MergeStacks(IRingNode stack);
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
                var ringnode = _ring.First();
                foreach (var node in _ring)
                    if (ringnode.Length > node.Length)
                        ringnode = node;

                return ringnode;
            }

            public void ReplaceWithNextNode(T node)
            {
                var nextNode = node.NextNode ?? node;
                nextNode.NextNode = node;
                nextNode.MergeStacks(node);
                var previousNode = _ring.Find(x => x.NextNode == (IRingNode)node);
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
            private  Stack<T> _storedData;
            public RingNode(Stack<T> storedData)
            {
                _storedData = storedData;
            }

            public Stack<T> StoredStack => _storedData;
            public int Length => _storedData.Count;
            public IRingNode NextNode { get; set; }

            public Stack Data()
            {
                return new Stack(_storedData);
            }

            public void MergeStacks(IRingNode stack)
            {

                foreach (var node in stack.Data())
                    _storedData.Push((T)node);
            }
        }
        Stack<int> values = new Stack<int>();
        Stack<int> buffer1 = new Stack<int>();
        Stack<int> buffer2 = new Stack<int>();
        List<int> list = new List<int>();
        
       
        
        public Form1()
        {
            InitializeComponent();
        }




        private void button3_Click(object sender, EventArgs e)
        {
           
                var group1 = new Stack<string>();
                group1.Push("Ivanov");
                group1.Push("Pyatkin");
                group1.Push("Oskin");

                var group2 = new Stack<string>();
                group2.Push("Lantsev");
                group2.Push("Kupalenko");

                var group3 = new Stack<string>();
                group3.Push("Petrova");
                group3.Push("Malyshev");
                group3.Push("Pipkin");
                group3.Push("Sergeev");

                var ring = new OneConnectedRing<RingNode<string>>();
                ring.Add(new RingNode<string>(group1));
                ring.Add(new RingNode<string>(group2));
                ring.Add(new RingNode<string>(group3));

                foreach (var node in ring)
                {
                richTextBox2.Text += node.Length;
                    foreach (var data in node.StoredStack)
                    {
                        richTextBox2.Text += $"\t {data} \n ";
                    }
                }

                ring.ReplaceWithNextNode(ring.Min());

                richTextBox2.Text += "-------------------------------- \n";

                foreach (var node in ring)
                {
                richTextBox2.Text += node.Length;
                    foreach (var data in node.StoredStack)
                    {
                        richTextBox2.Text += $"\t {data} \n";
                    }
                }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
          
            values.Push(Int32.Parse(textBox1.Text));
            richTextBox1.Text= Convert.ToString(values.Peek()) + " " + richTextBox1.Text;
            
        }
        private void Sort()
        {
            buffer1.Push(values.Pop());
           /* list = values.ToList();
            list.Sort();*/
            while (values.Count > 0)
            {
               if(values.Peek()<buffer1.Peek())
                    {
                        buffer1.Push(values.Pop());
                    }
               else {
                        buffer2.Push(values.Pop());
                    }
            }
            while(buffer1.Count > 0 && buffer1.Count != 0)
            {
                values.Push(buffer1.Pop());
            }
            while (buffer2.Count >= 0 && buffer2.Count > 0)
            {
                values.Push(buffer2.Pop());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;
            Sort();
            list = values.ToList();
             foreach(var item in list)
            {
                richTextBox1.Text += Convert.ToString(item)+ " ";
            }
            
        }

       

       
    }
}
