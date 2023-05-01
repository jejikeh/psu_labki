namespace Todo.Backend.Application.Interfaces;

public interface ITodoRepository
{
    public Task<IEnumerable<Models.Todo>> GetAllTodos();
    public Task<Models.Todo?> GetTodo(Guid id);
    public Task CreateTodo(Models.Todo todo);
    public Task UpdateTodo(Models.Todo todo);
    public Task DeleteTodo(Guid id);
    public Task<int> SaveChangesAsync();
}