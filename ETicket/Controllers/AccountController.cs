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
    }
}
