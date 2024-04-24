using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresentationProject.Web.Models;

namespace PresentationProject.Web.Infrastructure.Configurations;

public class RandomDeveloperSeederConfiguration : IEntityTypeConfiguration<Developer>
{
    public const int DevelopersCount = 10;
    
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.HasData(GenerateRandomDevelopers());
    }

    private static IEnumerable<Developer> GenerateRandomDevelopers()
    {
        var developers = new List<Developer>();

        for (var i = 1; i <= DevelopersCount; i++)
        {
            developers.Add(new Developer
            {
                Id = i,
                Name = $"Developer {i}"
            });
        }

        return developers;
        
    }
}