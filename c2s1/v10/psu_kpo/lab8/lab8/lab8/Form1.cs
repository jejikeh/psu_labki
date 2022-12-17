namespace lab8
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            char targetSymbol = s.Last();
            string res = String.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == targetSymbol)
                {
                    res = res + i.ToString() + ", ";
                }

            }
            richTextBox1.Text = res.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            s = s.Replace("word", "letter");
            richTextBox1.Text = s.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            int cnt = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                cnt++;
                if (cnt % 3 == 0)
                {
                    s = s.Insert(i, " ");
                }
            }
            richTextBox1.Text = s.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                string s= textBox1.Text;
                char[] arr = s.ToCharArray();
                int cnt = 0;
                foreach (char c in arr)
                {
                    if (c == '(')
                        cnt++;
                    else if (c == ')')
                        cnt--;

                    if (cnt == 0)
                    {
                        richTextBox1.Text = "Correct";
                    }

                    else
                    {
                        richTextBox1.Text = "Wrong";
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
