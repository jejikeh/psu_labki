using System.Media;

namespace Flow
{
    public partial class MainMenu : Form
    {
        private Dictionary<string, int> _scores = new Dictionary<string, int>();
        public SoundPlayer PressSound = new SoundPlayer("1.wav");
        public SoundPlayer WinSound = new SoundPlayer("2.wav");
        public SoundPlayer DeadSound = new SoundPlayer("3.wav");


        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PressSound.Play();
            new Flow(this);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AddToScoreList(int score)
        {
            listView1.Items.Clear();
            if(_scores.ContainsKey(textBox1.Text == string.Empty ? "Unknow" : textBox1.Text))
                _scores[textBox1.Text == string.Empty ? "Unknow" : textBox1.Text] = _scores[textBox1.Text == string.Empty ? "Unknow" : textBox1.Text] < score ? score : _scores[textBox1.Text == string.Empty ? "Unknow" : textBox1.Text];
            else
                _scores.Add(textBox1.Text == string.Empty ? "Unknow": textBox1.Text, score);

            foreach(var s in _scores.OrderByDescending(x => x.Value))
                listView1.Items.Add($"{s.Key}:{s.Value}\n");
        }
    }
}
