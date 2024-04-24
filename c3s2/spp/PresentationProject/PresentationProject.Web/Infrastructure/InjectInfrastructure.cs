using Microsoft.EntityFrameworkCore;

namespace PresentationProject.Web.Infrastructure;

public static class InjectInfrastructure
{
    public static IServiceCollection UseSqlite(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<PresentationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
        
        return serviceCollection;
    }
}