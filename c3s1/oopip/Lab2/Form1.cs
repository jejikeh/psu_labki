using Lab2.Models;
using Lab2.Persistence;
using Lab2.Services;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private readonly UserRepository _userRepository;
        private readonly FilmRepository _filmRepository;
        private readonly FilmSearchService _filmSearchService;
        private readonly FilmSearchFlags _filmSearchFlags = new FilmSearchFlags();

        public Form1()
        {
            InitializeComponent();

            _userRepository = new UserRepository();
            _filmRepository = new FilmRepository();
            _filmSearchService = new FilmSearchService(_filmRepository);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            listView1.Items.Clear();

            _filmSearchFlags.Year = DateOnly.TryParse(textBox4.Text, out var c) ? c : null;
            _filmSearchFlags.Title = textBox1.Text == string.Empty ? null : textBox1.Text;
            _filmSearchFlags.Country = textBox2.Text == string.Empty ? null : textBox2.Text;
            _filmSearchFlags.Rating = textBox3.Text == string.Empty ? null : int.Parse(textBox3.Text);
            _filmSearchFlags.FilmType = comboBox1.Text == string.Empty ? null : Enum.Parse<FilmType>(comboBox1.Text);

            foreach (var item in _filmSearchService.Search(_filmSearchFlags))
            {
                listView1.Items.Add(new ListViewItem(item.GenerateRow()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Create(_filmRepository);
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var faker = new Bogus.Faker();

            foreach (var _ in Enumerable.Range(1, Random.Shared.Next(20)))
            {
                _filmRepository.CreateFilm(new Film()
                {
                    Id = Guid.NewGuid(),
                    Country = faker.Address.Country(),
                    Rating = Random.Shared.Next(100),
                    FilmType = (FilmType)Random.Shared.Next(2),
                    Title = faker.Commerce.ProductMaterial(),
                    Release = faker.Date.PastDateOnly(),
                });
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = new Delete(_filmRepository);
            x.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var x = new Delete(_filmRepository, true);
            x.ShowDialog();
        }
    }
}