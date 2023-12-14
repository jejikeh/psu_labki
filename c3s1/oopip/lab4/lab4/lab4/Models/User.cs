namespace lab4.Models;

public class User
{
    public string Name { get; set; }
    private readonly List<Movie> _movies = new List<Movie>();
    
    public List<Movie> LookupNewMovies()
    {
        return _movies;
    }

    public void AddMovie(Movie movie)
    {
        _movies.Add(movie);
    }
    
    public void ClearMovies() => _movies.Clear(); 
}