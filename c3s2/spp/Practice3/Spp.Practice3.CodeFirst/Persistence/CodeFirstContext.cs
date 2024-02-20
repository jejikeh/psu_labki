using Microsoft.EntityFrameworkCore;
using Spp.Practice3.CodeFirst.Domain;

namespace Spp.Practice3.CodeFirst.Persistence;

class CodeFirstDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Note> Notes => Set<Note>();

    public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(user => user.Notes)
            .WithOne(note => note.User)
            .HasForeignKey(note => note.UserId)
            .IsRequired();
    }
}