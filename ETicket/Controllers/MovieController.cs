using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class MovieController : Controller
    {
        private readonly IMovieService db;
        public MovieController(IMovieService _db)
        {
            db = _db;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var d=await  db.GetAllAsync(n => n.Cinema);
            return View(d);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var d = await db.GetAllAsync(n => n.Cinema);
            if(!string.IsNullOrEmpty(searchString))
                {
               var resu = d.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", resu);
            }
            return View("Index",d);
        }
        [AllowAnonymous]
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
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVm v)
        {
            await db.AddNewMovie(v);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var mm=await db.GetMovieById(Id);
            if (mm == null)
                return View("NotFound");
            var response = new NewMovieVm()
            {
                Id = mm.Id,
                Name = mm.Name,
                Description = mm.Description,
                Price = mm.Price,
                ImageUrl = mm.ImageUrl,
                MovieCategory = mm.MovieCategory,
                CinemaId = mm.CinemaId,
                ProducerId = mm.ProducerId,
                ActorIds = mm.Actors_Movies.Select(n => n.ActorId).ToList()
            };
            var dd = await db.GetNewMovieDropdown();
            ViewBag.CinemaId = new SelectList(dd.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(dd.Producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(dd.Actors, "Id", "FullName");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVm v)
        {
            if (id != v.Id)
                return View("NotFound");
            await db.UpdateMovie(v);
            return RedirectToAction("Index");
        }


    }
}
