namespace lab4.Models;

public interface IMovieObserver
{
    public void AddMovie(Movie m);
    public List<Movie> LookupNewMovies();
    public void ClearMovies();
}