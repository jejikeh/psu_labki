using System.Net;
using System.Text;
using System.Text.Json;
using lab4;
using lab4.Models;
using lab4.Services;
using lab4.Services.DataProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using var factory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = factory.CreateLogger("Program");

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var movies = new MovieRepository(configuration["ConnectionStrings:DefaultConnection"] ?? throw new InvalidOperationException(), logger);
var users = new Dictionary<string, User>();

var listener = new HttpListener();
listener.Prefixes.Add(configuration["ASPNETCORE_URLS"]?.Split(";").First() ?? "http://localhost:5000/");
listener.Start();

logger.LogInformation("Listening for connections on {prefix}", listener.Prefixes.First() + "...");

await movies.InitMovieTable();

if (configuration["Runtime:InitData"] == "true")
{
    logger.LogInformation("Start inserting data");
    for (var i = 0; i < 1000; i++)
    {
        await movies.AddMovie(new Movie
        {
            Title = $"Movie {i}",
            Description = $"Description {i}",
            Genre = $"Genre {i}",
            Release = i,
            Rating = i
        });
    }
}

await Task.Run(async () =>
{
    var isRunning = true;
    
    while (isRunning)
    {
        var context = listener.GetContext();
        
        var request = context.Request;
        var response = context.Response;
        response.ContentType = "text/plain";
        response.StatusCode = (int) HttpStatusCode.OK;
        response.ContentEncoding = Encoding.UTF8;
        
        logger.LogInformation("{method} {url}", request.HttpMethod, request.Url);

        if (request is { HttpMethod: "POST", Url.PathAndQuery: "/shutdown" })
        {
            logger.LogInformation("Shutting down...");
            isRunning = false;
        }
        
        if (request is { HttpMethod: "POST", Url.PathAndQuery: "/movie" })
        {
            var body = new StreamReader(request.InputStream).ReadToEnd();
            var movie = JsonSerializer.Deserialize<Movie>(body);
            if (movie is null)
            {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                response.Close();
                continue;
            }
            
            await movies.AddMovie(movie);
            var data = Encoding.UTF8.GetBytes($"{movie.Title} added");
            await response.OutputStream.WriteAsync(data, 0, data.Length);
        }
        
        if (request is { HttpMethod: "GET", Url.PathAndQuery: "/xml/movie" })
        {
            response.ContentType = "application/xml";
            var data = await movies.SerializeGetMoviesUsingDataProviderAsync(new XmlDataProvider());
            await response.OutputStream.WriteAsync(
                data, 
                0, 
                data.Length);
        }
        
        if (request is { HttpMethod: "GET", Url.PathAndQuery: "/xmlfast/movie" })
        {
            response.ContentType = "application/xml";
            var data = await movies.SerializeGetMoviesUsingDataProviderAsync(new XmlFastDataProvider());
            await response.OutputStream.WriteAsync(
                data, 
                0, 
                data.Length);
        }
        
        if (request is { HttpMethod: "GET", Url.PathAndQuery: "/text/movie" })
        {
            response.ContentType = "plain/text";
            var data = await movies.SerializeGetMoviesUsingDataProviderAsync(new TextDataProvider());
            await response.OutputStream.WriteAsync(
                data, 
                0, 
                data.Length);
        }
        
        if (request is { HttpMethod: "GET", Url.PathAndQuery: "/json/movie" })
        {
            response.ContentType = "application/json";
            var data = await movies.SerializeGetMoviesUsingDataProviderAsync(new JsonDataProvider());
            await response.OutputStream.WriteAsync(
                data, 
                0, 
                data.Length);
        }
        
        if (request is { HttpMethod: "GET", Url.PathAndQuery: "/main" })
        {
            response.ContentType = "text/html";
            if (request.Cookies.All(x => x.Name != "user-id"))
            {
                var userId = Guid.NewGuid().ToString();
                var cookie = new Cookie("user-id", userId);
                response.Cookies.Add(cookie);
                
                var user = new User
                {
                    Name = userId
                };
                
                users.Add(userId, user);
                movies.OnMovieAdded += user.AddMovie;
                
                await response.OutputStream.WriteAsync(
                    StaticPages.SubscribeToUpdateMovies(userId),
                    0,
                    StaticPages.SubscribeToUpdateMovies(userId).Length
                );
            }
            else
            {
                var userId = request.Cookies
                    .First(x => x.Name == "user-id");

                if (!users.TryGetValue(userId.Value, out var user))
                {
                    var newUser = new User
                    {
                        Name = userId.Value
                    };
                    
                    users.Add(userId.Value, newUser);
                    movies.OnMovieAdded += newUser.AddMovie;
                    user = newUser;
                }
                
                await response.OutputStream.WriteAsync(
                    StaticPages.SeeUpdateMovies(userId.Value),
                    0,
                    StaticPages.SeeUpdateMovies(userId.Value).Length
                );
                
                var newMovies = user.LookupNewMovies(); 
                var data = new JsonDataProvider().ConvertToDataProvider(newMovies);
                await response.OutputStream.WriteAsync(
                    data,
                    0,
                    data.Length
                );
                
                user.ClearMovies();
            }
        }
        
        if (request is { HttpMethod: "GET", Url.PathAndQuery: "/unsub" })
        {
            response.ContentType = "text/html";
            if (request.Cookies.Any(x => x.Name == "user-id"))
            {
                var userId = request.Cookies["user-id"];
                if (!users.TryGetValue(userId.Value, out var user)) continue;
                movies.OnMovieAdded -= user.AddMovie;
                await response.OutputStream.WriteAsync(
                    StaticPages.UnSubscribeToUpdateMovies(userId.Value),
                    0,
                    StaticPages.UnSubscribeToUpdateMovies(userId.Value).Length
                );
            }
        }
        
        response.Close();
    }
});