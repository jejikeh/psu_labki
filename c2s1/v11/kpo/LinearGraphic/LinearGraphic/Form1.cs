namespace LinearGraphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _startAxisX = 250;
        private int _startAxisY = 0;
        private int _size = 1;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen p = new Pen(Color.Red, 1);
            DrawAxis(g, p, 60, 0, 60, 600);
            DrawAxis(g, p, -100, 300, 900, 300);
            Point[] points = new Point[]
            {
                new Point(1,CalculateFunction(5,1)),
                new Point(2,CalculateFunction(5,2)),
                new Point(3,CalculateFunction(5,3)),
                new Point(4,CalculateFunction(5,4)),
                new Point(5,CalculateFunction(5,5)),
            };

            for(int i = 1; i < points.Length; i += 2)
            {
                g.DrawLine(p, points[i - 1].X + 500, points[i - 1].Y + 250, points[i].X + 500, points[i].Y + 250);
            }
        }

        private int CalculateFunction(int a,int x) => a * x;

        private void DrawAxis(Graphics g, Pen p, int x, int y,int x1, int y1) => g.DrawLine(p, x + _startAxisX, y + _startAxisY, x1 + _startAxisX, y1 + _startAxisY);
    }
}