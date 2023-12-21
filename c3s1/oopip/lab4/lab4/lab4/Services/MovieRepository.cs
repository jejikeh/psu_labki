using lab4.Models;
using lab4.Services.DataProviders;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace lab4.Services;

public class MovieRepository : IObservedSubject
{
    private readonly NpgsqlConnection _connection;
    private readonly ILogger _logger;
    
    public event Action<Movie>? OnMovieAdded;
    
    public MovieRepository(string connectionString, ILogger logger)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        var dataSource = dataSourceBuilder.Build();

        _logger = logger;
        _connection = dataSource.OpenConnection();
    }
    
    public async Task InitMovieTable()
    {
        await using var command = new NpgsqlCommand(
            "CREATE TABLE IF NOT EXISTS Movies (" +
                "Id SERIAL NOT NULL PRIMARY KEY, " +
                "Title TEXT NOT NULL, " +
                "Description TEXT NOT NULL, " +
                "Genre TEXT NOT NULL, " +
                "Release int NOT NULL, " +
                "Rating int NOT NULL)",
            _connection);
        
        await command.ExecuteNonQueryAsync();
        _logger.LogInformation("Movies table created");
    }

    public async Task AddMovie(Movie movie)
    {
        await using var command = new NpgsqlCommand(
            "INSERT INTO Movies (Title, Description, Genre, Release, Rating) VALUES (@Title, @Description, @Genre, @Release, @Rating)", _connection);
        command.Parameters.AddWithValue("Title", movie.Title);
        command.Parameters.AddWithValue("Description", movie.Description);
        command.Parameters.AddWithValue("Genre", movie.Genre);
        command.Parameters.AddWithValue("Release", movie.Release);
        command.Parameters.AddWithValue("Rating", movie.Rating);
        
        await command.ExecuteNonQueryAsync();
        _logger.LogInformation("Movie added: {movie}", movie.Title);
        
        OnMovieAdded?.Invoke(movie);
    }

    public async IAsyncEnumerable<Movie> GetMovies()
    {
        await using var command = new NpgsqlCommand(
            "SELECT * FROM Movies", _connection);
        
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            yield return new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Description = reader.GetString(2),
                Genre = reader.GetString(3),
                Release = reader.GetInt32(4),
                Rating = reader.GetInt32(5)
            };
        }
    }

    public async Task<byte[]> SerializeGetMoviesUsingDataProviderAsync(IMovieDataProvider dataProvider)
    {
        var output = ""u8.ToArray();
        await foreach (var x in GetMovies())
        {
            var data = dataProvider.ConvertToDataProvider(x);
            output = output.Concat(data).ToArray();
        }
        
        return output;
    }

    public void AddObserver(IMovieObserver observer)
    {
        OnMovieAdded += observer.AddMovie;
    }

    public void RemoveObserver(IMovieObserver observer)
    {
        OnMovieAdded -= observer.AddMovie;
    }
}