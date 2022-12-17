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
        public Form1()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(1000, 1000);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Pen myPen = new Pen(Color.Blue);
            int k = 100;
            float xmin = 500, xmax = 1000;
            float xstep = 100;
            float x1 = xmin, y1 = x1 * x1, x2, y2;
            float ymax= 1000;
            float kx = this.Width / xmax, ky = this.Height / ymax;
            for (int i = 0; i < k; i++)
            {
                x2 = x1 + xstep;
                y2 = x2 * x2;
                gr.DrawLine(myPen, x1, y1,x2,y2);
                x1 = x2;
                y1 = y2;
            }
        }
        }
    }
