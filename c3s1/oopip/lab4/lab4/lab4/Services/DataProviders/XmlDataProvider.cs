using System.Text;
using System.Xml.Serialization;
using lab4.Models;

namespace lab4.Services.DataProviders;

public class XmlDataProvider : IMovieDataProvider
{
    public byte[] ConvertToDataProvider(Movie movie)
    {
        var xmlSerializer = new XmlSerializer(typeof(Movie));
        var stringStream = new StringWriter();
        xmlSerializer.Serialize(stringStream, movie);
        
        return Encoding.UTF8.GetBytes(stringStream.ToString());
    }

    public byte[] ConvertToDataProvider(IEnumerable<Movie> movies)
    {
        var xmlSerializer = new XmlSerializer(typeof(IEnumerable<Movie>));
        var stringStream = new StringWriter();
        xmlSerializer.Serialize(stringStream, movies);
        
        return Encoding.UTF8.GetBytes(stringStream.ToString());
    }
}