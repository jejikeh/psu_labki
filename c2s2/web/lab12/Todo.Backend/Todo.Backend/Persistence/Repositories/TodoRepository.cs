using Microsoft.EntityFrameworkCore;
using Todo.Backend.Application.Interfaces;

namespace Todo.Backend.Persistence.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Models.Todo>> GetAllTodos()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Models.Todo?> GetTodo(Guid id)
    {
        return await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
    }

    public async Task CreateTodo(Models.Todo todo)
    {
        await _context.AddAsync(todo);
    }

    public async Task UpdateTodo(Models.Todo todo)
    {
        var updateTodo = await GetTodo(todo.Id);
        if (updateTodo is null)
            return;

        updateTodo.Title = todo.Title;
        updateTodo.EndDate = todo.EndDate;
        updateTodo.IsDone = todo.IsDone;
    }

    public async Task DeleteTodo(Guid id)
    {
        var todo = await GetTodo(id);
        if (todo is null)
            return;

        _context.Todos.Remove(todo);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}