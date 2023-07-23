using ETicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext db;
        public MovieController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            var d=await  db.Movies.ToListAsync();
            return View(d);
        }
    }
}
