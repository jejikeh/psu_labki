using System.Text;
using lab4.Models;

namespace lab4.Services.DataProviders;

public class TextDataProvider : IMovieDataProvider
{
    public byte[] ConvertToDataProvider(Movie movie)
    {
        return Encoding.UTF8.GetBytes($"{movie.Title} {movie.Description} {movie.Genre} {movie.Release} {movie.Rating}\n");
    }

    public byte[] ConvertToDataProvider(IEnumerable<Movie> movies)
    {
        var sb = new StringBuilder();
        foreach (var movie in movies)
        {
            sb.AppendLine(ConvertToDataProvider(movie).ToString());
        }
        
        return Encoding.UTF8.GetBytes(sb.ToString());
    }
}