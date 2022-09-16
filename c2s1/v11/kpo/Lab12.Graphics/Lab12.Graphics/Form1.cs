using System.Drawing;
using System.Windows.Forms;

namespace Lab12.Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 640;
            this.Height = 480;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Brush red = new SolidBrush(Color.Red);
            Brush white = new SolidBrush(Color.White);
            // big cirlce
            g.FillEllipse(white,new Rectangle((this.Width/2) - 100,this.Height/2,200,200));
            g.DrawEllipse(pen, new Rectangle((this.Width / 2) - 100, this.Height / 2, 200, 200));

            // mid circle
            g.FillEllipse(white, new Rectangle((this.Width / 2) - 50, (this.Height / 2) - 100, 100, 100));
            g.DrawEllipse(pen, new Rectangle((this.Width / 2) - 50, (this.Height / 2) - 100, 100, 100));
            // head
            g.FillEllipse(white, new Rectangle((this.Width / 2) - 25, (this.Height / 2) - 150, 50, 50));
            g.DrawEllipse(pen, new Rectangle((this.Width / 2) - 25, (this.Height / 2) - 150, 50, 50));
            // hands
            g.FillEllipse(white, new Rectangle((this.Width / 2) + 50, (this.Height / 2) - 100, 30, 30));
            g.DrawEllipse(pen, new Rectangle((this.Width / 2) + 50, (this.Height / 2) - 100, 30, 30));

            g.FillEllipse(white, new Rectangle((this.Width / 2) - 80, (this.Height / 2) - 100, 30, 30));
            g.DrawEllipse(pen, new Rectangle((this.Width / 2) - 80, (this.Height / 2) - 100, 30, 30));

            // bucket
            g.DrawRectangle(pen, new Rectangle((this.Width /2 - 15), (this.Width /2 - 266),30,40));
            g.FillRectangle(red, new Rectangle((this.Width / 2 - 15), (this.Width / 2 - 266), 30, 40));
            // eyes
            g.FillRectangle(red, new Rectangle((this.Width / 2 - 10), (this.Width / 2 - 210), 10, 10));
            g.FillRectangle(red, new Rectangle((this.Width / 2 + 10), (this.Width / 2 - 210), 10, 10));


            Point[] nose = new Point[4]
            {
                new Point(this.Width/2,this.Height/2 - 120),
                new Point(this.Width/2 + 30, this.Height/2 - 110),
                new Point(this.Width/2, this.Height/2 - 107),
                new Point(this.Width/2,this.Height/2 - 120)
            };

            g.FillPolygon(red, nose);


        }
    }
}