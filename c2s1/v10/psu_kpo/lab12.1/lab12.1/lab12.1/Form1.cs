using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BackColor = Color.Blue;

        }
       

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Graphics h = CreateGraphics();
            Pen pen = new Pen(Color.Yellow, 2);
            Random r1 = new Random(10000);
            Random r2 = new Random(10000);
            for (int i = 0; i < 1000; i++)
            {
                int x = r1.Next() % ClientSize.Width;
                int y = r1.Next() % ClientSize.Height;
                if (r2.NextDouble() > 0.1)
                {
                    h.DrawLine(pen, x, y, x+1, y+1);
                }
            }
            Invalidate();
        }
    }
}
