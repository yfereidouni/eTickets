using eTickets.Data;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers;

public class AccountsController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AppDbContext _context;

    public AccountsController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    [HttpGet]
    public IActionResult Login() => View(new LoginVM());

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid)
            return View(loginVM);

        var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movies");
                }
            }
            else
            {
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }
        }

        TempData["Error"] = "Wrong credentials. Please, try again!";
        return View(loginVM);
    }
}
