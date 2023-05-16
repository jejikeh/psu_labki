using Microsoft.EntityFrameworkCore;
using Todo.Backend.Persistence.Configurations;

namespace Todo.Backend.Persistence;

public class TodoDbContext : DbContext
{
    public DbSet<Models.Todo> Todos { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new TodoConfiguration());
    }
}