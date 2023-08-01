using ETicket.Data;
using ETicket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Create() 
        {
            var dd = await db.GetNewMovieDropdown();
            ViewBag.CinemaId = new SelectList(dd.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(dd.Producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(dd.Actors, "Id", "FullName");

            return View();
        }

    }
}
