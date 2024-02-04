using System.Reflection;

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

app.Run();


internal class Photo
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}