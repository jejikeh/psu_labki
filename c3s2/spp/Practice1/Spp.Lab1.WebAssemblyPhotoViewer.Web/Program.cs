using System.Reflection;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapGet("images", () =>
{
    var imagesFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, "images"));

    return imagesFiles.Select(imageFile => new Photo { Name = Path.GetFileName(imageFile), Content = Convert.ToBase64String(File.ReadAllBytes(imageFile)) });
});

app.MapGet("images-view", () =>
{
    var imagesFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, "images"));

    var photos = imagesFiles.Select(imageFile => new Photo { Name = Path.GetFileName(imageFile), Content = Convert.ToBase64String(File.ReadAllBytes(imageFile)) }).ToList();

    var htmlRender = string.Empty;
    foreach (var photo in photos)
    {
        htmlRender += $"<h1>{photo.Name}</h1>";
        htmlRender += $"<img src=\"data:image; base64, {photo.Content}\" style = \"width:640px;height:480px;\" />";
    }

    return Results.Text(content: htmlRender, contentType: "text/html");
});


app.Run();


internal class Photo
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}