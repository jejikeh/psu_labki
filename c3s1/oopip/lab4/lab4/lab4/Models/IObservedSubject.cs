namespace lab4.Models;

public interface IObservedSubject
{
    public void AddObserver(IMovieObserver observer);
    public void RemoveObserver(IMovieObserver observer);
}