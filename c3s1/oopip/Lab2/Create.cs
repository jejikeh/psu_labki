using Lab2.Models;
using Lab2.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Create : Form
    {
        private readonly FilmRepository _filmRepository;
        private Film? ff;
        private bool _update;

        public Create(FilmRepository filmRepository)
        {
            InitializeComponent();
            _filmRepository = filmRepository;
        }

        public Create(FilmRepository filmRepository, Film f)
        {
            InitializeComponent();
            _filmRepository = filmRepository;
            ff = f;
            _update = true;

            textBox1.Text = ff.Title;
            textBox2.Text = ff.Country;
            textBox3.Text = ff.Rating.ToString();
            comboBox1.Text = ff.FilmType.ToString();
            textBox4.Text = ff.Release.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_update)
            {
                _filmRepository.UpdateFilm(new Models.Film()
                {
                    Id = ff.Id,
                    Title = textBox1.Text,
                    Country = textBox2.Text,
                    Rating = int.Parse(textBox3.Text),
                    FilmType = Enum.Parse<FilmType>(comboBox1.Text),
                    Release = DateOnly.Parse(textBox4.Text),
                });
                Close();
                return;
            }

            _filmRepository.CreateFilm(new Models.Film()
            {
                Id = Guid.NewGuid(),
                Title = textBox1.Text,
                Country = textBox2.Text,
                Rating = int.Parse(textBox3.Text),
                FilmType = Enum.Parse<FilmType>(comboBox1.Text),
                Release = DateOnly.Parse(textBox4.Text),
            });

            Close();
        }
    }
}
