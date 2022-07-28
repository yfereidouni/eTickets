using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class ProducersController : Controller
{
    private readonly IProducersService _producersService;

    public ProducersController(IProducersService producersService)
    {
        _producersService = producersService;
    }

    public async Task<IActionResult> Index()
    {
        var producers = await _producersService.GetAllAsync();
        return View(producers);
    }

    // GET: Actors/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
    {
        //ModelState.Remove("Actors_Movies");
        if (ModelState.IsValid)
        {
            await _producersService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        return View(producer);
    }


    //GET: producers/details/1
    public async Task<IActionResult> Details(int id)
    {
        var producersDetails = await _producersService.GetByIdAsync(id);
        
        if (producersDetails is null) 
            return View("NotFound");
        
        return View(producersDetails);
    }

    // GET: Producers/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var producer = await _producersService.GetByIdAsync(id);

        if (producer == null) return View("NotFound"); //return NotFound();

        return View(producer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Producer producer)
    {
        //ModelState.Remove("Actors_Movies");
        if (ModelState.IsValid)
        {
            await _producersService.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        return View(producer);
    }

    // GET: Producers/Delete/1
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var producer = await _producersService.GetByIdAsync(id);

        if (producer == null) return View("NotFound"); //return NotFound();

        return View(producer);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Producer producer)
    {
        var producerInDb = await _producersService.GetByIdAsync(producer.Id);

        if (producerInDb == null) return View("NotFound"); //return NotFound();

        await _producersService.DeleteAsync(producer.Id);

        return RedirectToAction(nameof(Index));
    }

}
