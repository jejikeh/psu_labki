using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationProject.Web.Infrastructure;
using PresentationProject.Web.Models;

namespace PresentationProject.Web.Controllers;

public class GameController([FromServices] PresentationDbContext context) : Controller
{
    public IActionResult Index(int page = 0, int pageSize = 10)
    {
        return View(GetPage(page, pageSize));
    }
    
    public IActionResult Details(int id)
    {
        return View(Get(id));
    }
    
    public IEnumerable<Game> GetPage(int page = 0, int pageSize = 10)
    {
        return context.Games.Skip(page * pageSize).Take(pageSize).ToList();
    }
    
    public Game Get(int id)
    {
        return context.Games.Include(game => game.Developer).FirstOrDefault(game => game.Id == id) 
               ?? throw new Exception("Game not found");
    }

    public void Post([FromBody] Game game)
    {
        context.Games.Add(game);
    }

    public void Put([FromBody] Game game)
    {
        context.Games.Update(game);
    }
}