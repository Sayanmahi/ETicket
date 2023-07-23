using ETicket.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicket.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext db;
        public CinemaController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var d= db.Producers.ToList();   
            return View();
        }
    }
}
