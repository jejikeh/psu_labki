using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba9
{
    public partial class Form1 : Form
    {
        struct Order
        {
            public string Plat;
            public string Plot;
            public string Sum;
        }
        private List<Order> _orders = new List<Order>();
        public void AddOrder(string plat, string plot, string sum)
        {
            var order = new Order();
            order.Plat = plat;
            order.Plot = plot;
            order.Sum = sum;
            _orders.Add(order);
           _orders = _orders.OrderBy(x => x.Plat).ToList();
            richTextBox1.Text = String.Empty;
            foreach(var x in _orders)
            {
                richTextBox1.Text += $"PLAT: {x.Plat} PLOT: {x.Plot} SUM: {x.Sum}\n";
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            for(int i = 0; i < _orders.Count; i++)
            {
                if (_orders[i].Plat == s)
                { 
                    textBox2.Text = _orders[i].Sum; 
                    break;
                }    
                else
                {
                    textBox2.Text = "Plat not found...";
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2= new Form2(this);
            form2.ShowDialog(this);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
