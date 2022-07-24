using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class ActorsController : Controller
{
    private readonly AppDbContext _appDbContext;

    public ActorsController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<IActionResult> Index()
    {
        var actors = await _appDbContext.Actors.ToListAsync();
        return View(actors);
    }
}
