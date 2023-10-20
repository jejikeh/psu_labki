using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Persistence
{
    public class FilmRepository
    {
        private readonly List<Film> _films = new List<Film>();

        public FilmRepository()
        {
            
        }

        public Film CreateFilm(Film film)
        {
            _films.Add(film);

            return film;
        }

        public void DeleteFilm(Film film) 
        {
            _films.Remove(film);
        }

        public void UpdateFilm(Film film)
        {
            var m = _films.FirstOrDefault(f => f.Id == film.Id);
            _films.Remove(m);
            _films.Add(film);
        }

        public Film? GetFilm(Guid id)
        {
            return _films.FirstOrDefault(f => f.Id == id);
        }

        public List<Film> GetFilms()
        {
            return _films;
        }
    }
}
