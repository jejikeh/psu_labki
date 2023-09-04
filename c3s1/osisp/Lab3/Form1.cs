namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            var game = new Game();
            game.Show();

            game.FormClosed += Game_FormClosed;

            Hide();
        }

        private void Game_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            var game = new Game(false);
            game.Show();

            game.FormClosed += Game_FormClosed;

            Hide();
        }
    }
}