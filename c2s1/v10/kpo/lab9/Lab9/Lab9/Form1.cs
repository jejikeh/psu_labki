namespace Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sender = 1;
            return (int)sender;
        }

        private int radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sender = 2;
            return (int)sender;
        }


        private int radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sender = 3;
            return (int)sender;
        }


        private void button1_Click(int sender, EventArgs e)
        {
           
            string Name;
            string Group;
            string Ses;
            if (sender==1)
            {
                Name = textBox1.Text;
            }
            if (sender == 1)
            {
                Group = textBox1.Text;
            }
            if (sender == 1)
            {
                Ses = textBox1.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
