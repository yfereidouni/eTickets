using eTickets.Data;
using eTickets.Data.Static;
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

    public IActionResult Login() => View(new LoginVM());

    //[HttpGet("{emailAddress}")]
    [ActionName("LoginWithDefaulValues")]
    public IActionResult Login(string emailAddress)
    {
        var loginVM = new LoginVM()
        {
            EmailAddress = emailAddress
        };

        return View("Login", loginVM);
    }

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

    public IActionResult Register() => View(new RegisterVM());

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid)
            return View(registerVM);

        var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

        if (user != null)
        {
            TempData["Error"] = "This email address is already in use.";
            return View(registerVM);
        }

        var newUser = new ApplicationUser
        {
            FullName = registerVM.FullName,
            Email = registerVM.EmailAddress,
            UserName = registerVM.EmailAddress,
        };

        var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

        if (newUserResponse.Succeeded)
            await _userManager.AddToRoleAsync(newUser, UserRoles.User);

        //If response was NOT success we should create modelError here

        return View("RegisterCompleted", registerVM);
    }

}
