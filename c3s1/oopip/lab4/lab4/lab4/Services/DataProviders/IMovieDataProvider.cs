using lab4.Models;

namespace lab4.Services.DataProviders;

public interface IMovieDataProvider
{
    public byte[] ConvertToDataProvider(Movie movie);
    public byte[] ConvertToDataProvider(IEnumerable<Movie> movies);
}