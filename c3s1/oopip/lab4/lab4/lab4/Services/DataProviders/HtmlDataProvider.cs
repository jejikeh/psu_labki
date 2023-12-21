using System.Text;
using lab4.Models;

namespace lab4.Services.DataProviders;

public class HtmlDataProvider : IMovieDataProvider
{
    public byte[] ConvertToDataProvider(Movie movie)
    {
        return Encoding.UTF8.GetBytes($"<h1>{movie.Title}</h1><p>{movie.Description}</p></br>");
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