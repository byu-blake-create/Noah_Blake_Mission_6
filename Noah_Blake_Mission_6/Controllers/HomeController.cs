using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Noah_Blake_Mission_6.Models;

namespace Noah_Blake_Mission_6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("Home");
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    public IActionResult AddMovie()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
