using ETicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppDbContext db;
        public ProducerController(AppDbContext _db)
        {
            db = _db;            
        }
        public async Task<IActionResult> Index()
        {
            var d= await db.Producers.ToListAsync();
            return View(d);
        }
    }
}
