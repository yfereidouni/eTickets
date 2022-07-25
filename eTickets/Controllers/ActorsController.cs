using eTickets.Data.Services;
using eTickets.Models;
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

    // GET: Actors/Create
    public IActionResult Create()
    {
        return View(new Actor());
    }

    [HttpPost]
    public IActionResult Create(Actor actor)
    {
        _actorsService.Add(actor);
        return RedirectToAction("Index");
    }


}
