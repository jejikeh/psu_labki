using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresentationProject.Web.Models;

namespace PresentationProject.Web.Infrastructure.Configurations;

public class RandomGameSeederConfiguration : IEntityTypeConfiguration<Game>
{
    public const int GamesCount = 100;
    
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasData(GenerateRandomGames());
    }

    private static IEnumerable<Game> GenerateRandomGames()
    {
        var games = new List<Game>();
        var random = new Random();

        for (var i = 1; i <= GamesCount; i++)
        {
            games.Add(new Game
            {
                Id = i,
                Title = $"Game {i}",
                Description = "Game description",
                Image = "game.png",
                Rating = random.Next(0, 10),
                ReleaseDate = DateOnly.FromDateTime(DateTime.Now).AddDays(random.Next(0, 365)),
                DeveloperId = random.Next(1, RandomDeveloperSeederConfiguration.DevelopersCount),
            });
        }
        
        return games;
    }
}