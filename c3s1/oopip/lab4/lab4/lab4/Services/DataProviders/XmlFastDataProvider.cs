using System.Text;
using System.Xml.Serialization;
using lab4.Models;

namespace lab4.Services.DataProviders;

public class XmlFastDataProvider : IMovieDataProvider
{
    public byte[] ConvertToDataProvider(Movie movie)
    {
        return Encoding.UTF8.GetBytes($"<Movie><Title>{movie.Title}</Title><Description>{movie.Description}</Description><Genre>{movie.Genre}</Genre><Release>{movie.Release}</Release><Rating>{movie.Rating}</Rating></Movie>");
    }

    public byte[] ConvertToDataProvider(IEnumerable<Movie> movies)
    {
        var xml = movies.Aggregate("<Movies>", (current, movie) => current + ConvertToDataProvider(movie));
        xml += "</Movies>";
        
        return Encoding.UTF8.GetBytes(xml);
    }
}