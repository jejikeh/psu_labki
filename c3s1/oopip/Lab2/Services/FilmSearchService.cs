using Lab2.Models;
using Lab2.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services
{
    public class FilmSearchFlags
    {
        public int? Rating { get; set; }
        public string? Title { get; set; }
        public DateOnly? Year { get; set; }
        public FilmType? FilmType { get; set; }
        public string? Country { get; set; }
    }

    public class FilmSearchService
    {
        private readonly FilmRepository _repository;

        public FilmSearchService(FilmRepository repository)
        {
            _repository = repository;
        }

        public List<Film> Search(FilmSearchFlags searchFlags)
        {
            var films = _repository.GetFilms();
    
            if (searchFlags.Year is not null)
            {
                films = films.Where(f => f.Release == searchFlags.Year).ToList();
            }

            if (searchFlags.Title is not null)
            {
                films = films.Where(f => f.Title == searchFlags.Title).ToList();
            }

            if (searchFlags.FilmType is not null)
            {
                films = films.Where(f => f.FilmType == searchFlags.FilmType).ToList();
            }

            if (searchFlags.Country is not null)
            {
                films = films.Where(f => f.Country == searchFlags.Country).ToList();
            }

            return films;
        }
    }
}
