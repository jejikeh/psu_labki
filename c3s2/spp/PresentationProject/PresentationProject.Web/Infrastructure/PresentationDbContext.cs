using Microsoft.EntityFrameworkCore;
using PresentationProject.Web.Infrastructure.Configurations;
using PresentationProject.Web.Models;

namespace PresentationProject.Web.Infrastructure;

public class PresentationDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Developer> Developers { get; set; }

    public PresentationDbContext(DbContextOptions<PresentationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RandomDeveloperSeederConfiguration());
        modelBuilder.ApplyConfiguration(new RandomGameSeederConfiguration());
    }
}