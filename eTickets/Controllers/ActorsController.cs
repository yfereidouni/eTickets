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
        return View();
    }

    [HttpPost]
    public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
    {
        //ModelState.Remove("Actors_Movies");
        if (ModelState.IsValid)
        {
            _actorsService.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        return View(actor);
    }

    // GET: Actors/Details/1
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var actor = _actorsService.GetById(id);
        
        if (actor == null) 
            return View("Empty");

        return View(actor);
    }
}
