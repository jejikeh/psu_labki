using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Film
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required DateOnly Release {get; set;}
        public required string Country { get; set; }
        public int Rating { get; set;}
        public FilmType FilmType { get; set; }

        private string _name { get; set; }

        public Film()
        {
            _name = $"{typeof(Film)}|{Id.ToString()}";
        }

        public string[] GenerateRow() {
            return new string[] {
                Id.ToString(),
                Title, 
                Rating.ToString(),
                Country,
                Release.ToString(),
                FilmType.ToString(),
            };
        }
    }
}
