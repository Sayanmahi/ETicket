using ETicket.Data;
using ETicket.Data.ViewModel;
using ETicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicket.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext appDbContext;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, AppDbContext _appDbContext)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            appDbContext = _appDbContext;
            
        }
        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return (View(loginVM));
            var user = await userManager.FindByEmailAsync(loginVM.EmailAddress);
            if(user !=null)
            {
                var passwordcheck = await userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordcheck)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movie");
                    }
                }
                TempData["Error"] = "Wrong Credentials please try again";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong Credentials please try again";
            return View(loginVM);
        }
    }
}
