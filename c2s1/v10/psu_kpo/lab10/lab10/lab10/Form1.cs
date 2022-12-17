using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s="";
            var n = Int32.Parse(textBox1.Text);
            for (int i = 0; i < n; i++)
            {
                s += "a";
            }
            var stream = File.ReadAllText("./sample1.txt").Split('\n');
            var newText = string.Empty;
            foreach (var line in stream.Where(x => x != string.Empty && x != "\r" && x != "\f" && x != "\n"))
            {
                newText += line.Replace("\r",s) + "\n";
            }

            File.WriteAllText("output1.txt", newText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var stream = File.ReadAllText("./sample2.txt").Split('\n');
            var newText = String.Empty;
            for (int i = 0; i < stream.Length; i++)
            {
                var Surname =  String.Empty;

                var result = 0;
                var sum = 0;
                var line = stream[i].Split(' ');
                Surname = line[0];
                for (int j = 1; j < line.Length-1; j++)
                {
                    sum += Int32.Parse(line[j]);
                }

                result = sum/(line.Length-2);
                if (result >= 4)
                {
                    newText += Surname.ToLower()+'\n';
                }
                
            }
            File.WriteAllText("output2.txt", newText);
        }

       
    }
}