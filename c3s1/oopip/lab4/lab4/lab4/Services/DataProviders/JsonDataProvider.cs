using System.Text;
using System.Text.Json;
using lab4.Models;

namespace lab4.Services.DataProviders;

public class JsonDataProvider : IMovieDataProvider
{
    public byte[] ConvertToDataProvider(Movie movie)
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(movie));
    }

    public byte[] ConvertToDataProvider(IEnumerable<Movie> movies)
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(movies));
    }
}