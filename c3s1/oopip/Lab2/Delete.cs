using Lab2.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Delete : Form
    {
        private readonly FilmRepository _repository;
        private bool _update;

        public Delete(FilmRepository filmRepository, bool update = false)
        {
            InitializeComponent();

            _repository = filmRepository;
            _update = update;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = Guid.TryParse(textBox1.Text, out var id);
            if (!f)
            {
                MessageBox.Show("Invalid GUID");
                return;
            }

            var film = _repository.GetFilm(id);
            if (film is null)
            {
                MessageBox.Show("Film was not found");
                return;
            }

            if (!_update)
            {
                _repository.DeleteFilm(film);
                Close();
            } else
            {
                var d = new Create(_repository, film);
                d.ShowDialog();
            }
        }
    }
}
