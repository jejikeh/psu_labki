using System.Reflection;
using Todo.Backend.Application;
using Todo.Backend.Application.Common.Mappings;
using Todo.Backend.Application.Interfaces;
using Todo.Backend.Persistence;

namespace Todo.Backend.Extensions;

public static class ServiceMiddlewareExtension
{
    public static WebApplicationBuilder RegisterServiceMiddleware(this WebApplicationBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(ITodoRepository).Assembly));
        });
        
        builder.Services
            .AddApplication()
            .AddPersistence(builder.Configuration);
        
        builder.Services.AddCors(options =>
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            }));
        
        return builder;
    }
    
    public static WebApplication InitializeServiceContextProvider(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var authorDbContext = serviceProvider.GetRequiredService<TodoDbContext>();
            authorDbContext.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            //
        }

        return app;
    }
}