namespace ProjectManager.Application.Services;

public interface IRepository<T>
{
    public Task<IEnumerable<T>> GetAllAsync(int skip = 0, int take = 0);
    public Task<IEnumerable<T>> GetAllByPredicateAsync(Func<T, bool> predicate, int skip = 0, int take = 0);
    public Task<T?> GetByPredicateAsync(Func<T, bool> predicate);
    public Task<T> CreateAsync(T attachment);
    public Task<T> UpdateAsync(T attachment);
    public void Delete(T attachment);
    
    public Task SaveChangesAsync();
}