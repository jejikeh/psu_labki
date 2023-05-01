using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.Backend.Persistence.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Models.Todo>
{
    public void Configure(EntityTypeBuilder<Models.Todo> builder)
    {
        builder.HasKey(todo => todo.Id);
        builder.Property(todo => todo.Title).HasMaxLength(512);
    }
}