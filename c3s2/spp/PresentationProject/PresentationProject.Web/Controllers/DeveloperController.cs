using Microsoft.AspNetCore.Mvc;
using PresentationProject.Web.Infrastructure;
using PresentationProject.Web.Models;

namespace PresentationProject.Web.Controllers;

public class DeveloperController(PresentationDbContext context) : Controller
{
    public IEnumerable<Developer> GetPage(int page = 0, int pageSize = 10)
    {
        return context.Developers.Skip(page * pageSize).Take(pageSize).ToList();
    }

    public Developer Get(int id)
    {
        return context.Developers.Find(id) ?? throw new Exception("Developer not found");
    }
}