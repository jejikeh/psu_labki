using Microsoft.EntityFrameworkCore;

namespace Spp.Practice3.CodeFirst.Persistence;

public static class InjectPersistence
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CodeFirst");

        services.AddDbContext<CodeFirstDbContext>(builder =>
        {
            builder.UseNpgsql(connectionString);
        });

        return services;
    }
}