using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemasService.GetAllAsync();
            return View(cinemas);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            //ModelState.Remove("Actors_Movies");
            if (ModelState.IsValid)
            {
                await _cinemasService.AddAsync(cinema);
                return RedirectToAction(nameof(Index));
            }

            return View(cinema);
        }

        // GET: Actors/Details/1
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);

            if (cinema == null) return View("NotFound"); //return NotFound();

            return View(cinema);
        }

        // GET: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);

            if (cinema == null) return View("NotFound"); //return NotFound();

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            //ModelState.Remove("Actors_Movies");
            if (ModelState.IsValid)
            {
                await _cinemasService.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }

            return View(cinema);
        }

        // GET: Actors/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);

            if (cinema == null) return View("NotFound"); //return NotFound();

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cinema cinema)
        {
            var cinemaInDb = await _cinemasService.GetByIdAsync(cinema.Id);

            if (cinemaInDb == null) return View("NotFound"); //return NotFound();

            await _cinemasService.DeleteAsync(cinema.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
