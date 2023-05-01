using Microsoft.EntityFrameworkCore;
using Todo.Backend.Application.Interfaces;
using Todo.Backend.Persistence.Repositories;

namespace Todo.Backend.Persistence;

public static class PersistenceInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<TodoDbContext>(
            optionsBuilder =>
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("todo-app-dev"));
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            },
            ServiceLifetime.Transient
        );
        
        serviceCollection.AddScoped<ITodoRepository, TodoRepository>();
        return serviceCollection;
    } 
}