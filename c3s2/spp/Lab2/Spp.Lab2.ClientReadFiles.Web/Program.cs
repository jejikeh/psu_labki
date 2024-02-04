using System.Collections;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("simple-message", () => "Hello From Server!");

app.MapGet("image", () =>
{
    var image = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, "images")).First();

    return Convert.ToBase64String(File.ReadAllBytes(image));
});

app.MapGet("table", () =>
{
    return new SomeData();
});

app.Run();


public class SomeData
{
    public int Id { get; set; } = Random.Shared.Next(10, 199);
    public string Name { get; set; } = "Hello, World";
    public int Cost { get; set; } = Random.Shared.Next(100, 2000);
}
