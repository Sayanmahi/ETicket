using ETicket.Data;
using ETicket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService db;
        public MovieController(IMovieService _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            var d=await  db.GetAllAsync(n => n.Cinema);
            return View(d);
        }
        public async Task<IActionResult> Details(int id)
        {
            var m = await db.GetMovieById(id);
            return View(m);
        }
        public IActionResult Create() 
        {
            return View();
        }

    }
}
