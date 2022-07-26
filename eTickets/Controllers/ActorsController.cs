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
        var actors = await _actorsService.GetAllAsync();
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
            _actorsService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        return View(actor);
    }

    // GET: Actors/Details/1
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var actor = await _actorsService.GetByIdAsync(id);

        if (actor == null) return View("NotFound"); //return NotFound();

        return View(actor);
    }

    // GET: Actors/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var actor = await _actorsService.GetByIdAsync(id);

        if (actor == null) return View("NotFound"); //return NotFound();

        return View(actor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Actor actor)
    {
        //ModelState.Remove("Actors_Movies");
        if (ModelState.IsValid)
        {
            await _actorsService.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        return View(actor);
    }


    // GET: Actors/Delete/1
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var actor = await _actorsService.GetByIdAsync(id);

        if (actor == null) return View("NotFound"); //return NotFound();

        return View(actor);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Actor actor)
    {
        var actorInDb = await _actorsService.GetByIdAsync(actor.Id);

        if (actorInDb == null) return View("NotFound"); //return NotFound();

        await _actorsService.DeleteAsync(actor.Id);

        return RedirectToAction(nameof(Index));
    }

}
