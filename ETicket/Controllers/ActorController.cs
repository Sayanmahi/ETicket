using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Models;
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
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            db.Add(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
