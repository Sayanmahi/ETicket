using ETicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext db;
        public CinemaController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            var d= await db.Cinemas.ToListAsync();   
            return View(d);
        }
    }
}
