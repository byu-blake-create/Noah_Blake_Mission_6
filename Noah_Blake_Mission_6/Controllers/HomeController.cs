using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        PopulateCategories();
        return View(new Movie());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddMovie(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            PopulateCategories(movie.CategoryId);
            return View(movie);
        }

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return RedirectToAction("Confirmation");
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ThenBy(m => m.Year)
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }

        PopulateCategories(movie.CategoryId);
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditMovie(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            PopulateCategories(movie.CategoryId);
            return View(movie);
        }

        var existingMovie = _context.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
        if (existingMovie == null)
        {
            return NotFound();
        }

        existingMovie.CategoryId = movie.CategoryId;
        existingMovie.Title = movie.Title;
        existingMovie.Year = movie.Year;
        existingMovie.Director = movie.Director;
        existingMovie.Rating = movie.Rating;
        existingMovie.Edited = movie.Edited;
        existingMovie.CopiedToPlex = movie.CopiedToPlex;
        existingMovie.LentTo = movie.LentTo;
        existingMovie.Notes = movie.Notes;

        _context.SaveChanges();
        return RedirectToAction(nameof(MovieList));
    }

    private void PopulateCategories(int? selectedCategoryId = null)
    {
        ViewBag.Categories = new SelectList(
            _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList(),
            nameof(Category.CategoryId),
            nameof(Category.CategoryName),
            selectedCategoryId
        );
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
