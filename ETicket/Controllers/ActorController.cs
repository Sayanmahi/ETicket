using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicket.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class ActorController : Controller
    {
       
        private readonly IActorService db;
        public ActorController(IActorService _db)
        {
            db = _db;
        }
        [AllowAnonymous]
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
            await db.Add(actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var a = await db.GetById(Id);
            if (a == null)
                return View("NotFound");
            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            await db.Update(Id,actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var a = await db.GetById(Id);
            
            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await  db.Delete(Id);
        

            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var d =await db.GetById(id);
            if (d == null)
                return View("NotFound");
            return View(d); 
        }
    }
}
