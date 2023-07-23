using ETicket.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicket.Controllers
{
    public class ActorController : Controller
    {
        private readonly AppDbContext db;
        public ActorController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var d= db.Actors.ToList();
            return View(d);
        }
    }
}
