using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Noah_Blake_Mission_6.Models;

namespace Noah_Blake_Mission_6.Controllers;

public class HomeController : Controller
{
    private readonly MovieContext _context;

    public HomeController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View("Home");
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        return View(new Movie());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddMovie(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return RedirectToAction("Confirmation");
    }

    public IActionResult Confirmation()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
