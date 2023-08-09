using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JiggysCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace JiggysCarRental.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CarDbContext _context;

    public HomeController(ILogger<HomeController> logger, CarDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return _context.Vehicles != null ?
                         View(await _context.Vehicles.ToListAsync()) :
                         Problem("Entity set 'CarDbContext.Vehicles'  is null.");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

