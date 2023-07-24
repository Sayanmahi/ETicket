using ETicket.Data;
using ETicket.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETicket.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService db;
        public ActorController(IActorService _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            var d=await db.GetAll();
            return View(d);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
