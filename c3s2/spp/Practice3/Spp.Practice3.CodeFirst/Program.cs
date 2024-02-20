using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spp.Practice3.CodeFirst.Common;
using Spp.Practice3.CodeFirst.Domain;
using Spp.Practice3.CodeFirst.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapGet("/users", async ([FromServices] CodeFirstDbContext dbContext) =>
{
    var users = await dbContext.Users
        .Include(user => user.Notes)
        .ToListAsync();

    return Results.Ok(users);
});

app.MapGet("/users/{id:guid}", async (Guid id, [FromServices] CodeFirstDbContext dbContext) =>
{
    var user = await dbContext.Users
        .Include(user => user.Notes)
        .FirstOrDefaultAsync(x => x.Id == id);

    return Results.Ok(user);
});

app.MapPost("/users", async (UserDto userDto, [FromServices] CodeFirstDbContext dbContext) =>
{
    var user = new User
    {
        NickName = userDto.NickName
    };

    dbContext.Users.Add(user);

    await dbContext.SaveChangesAsync();

    return Results.Created($"/users/{user.Id}", user);
});

app.MapGet("/users/{id:guid}/notes/{noteId:guid}", async (Guid id, Guid noteId, [FromServices] CodeFirstDbContext dbContext) =>
{
    var notes = await dbContext.Notes.Where(x => x.Id == noteId && x.UserId == id).ToListAsync();

    return Results.Ok(notes);
});

app.MapGet("/users/{id:guid}/notes", async (Guid id, [FromServices] CodeFirstDbContext dbContext) =>
{
    var notes = await dbContext.Notes.Where(x => x.UserId == id).ToListAsync();

    return Results.Ok(notes);
});

app.MapPost("/users/{id:guid}/notes", async (Guid id, NoteDto noteDto, [FromServices] CodeFirstDbContext dbContext) =>
{
    var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

    if (user is null)
    {
        return Results.NotFound();
    }

    var note = new Note
    {
        Content = noteDto.Content,
        UserId = user.Id
    };

    dbContext.Notes.Add(note);

    await dbContext.SaveChangesAsync();

    return Results.Created($"/users/{user.Id}/notes/{note.Id}", note);
});

using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

try
{
    var dbContext = serviceProvider.GetRequiredService<CodeFirstDbContext>();
    await dbContext.Database.MigrateAsync();

    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine("Host terminated unexpectedly");
    Console.WriteLine(ex);
}
