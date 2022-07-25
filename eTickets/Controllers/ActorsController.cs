using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class ActorsController : Controller
{
    private readonly IActorsService _actorsService;

    public ActorsController(IActorsService actorsService)
    {
        _actorsService = actorsService;
    }

    public async Task<IActionResult> Index()
    {
        var actors = await _actorsService.GetAll();
        return View(actors);
    }
}
