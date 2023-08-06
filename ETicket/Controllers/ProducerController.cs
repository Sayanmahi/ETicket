using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class ProducerController : Controller
    {
        private readonly IProducerService db;
        public ProducerController(IProducerService _db)
        {
            db = _db;            
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var d = await db.GetAll(); ;
            return View(d);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int Id)
        {
            var d= await db.GetById(Id);
            if (d == null)
                return View("NotFound");
            return View(d);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName,Bio")]Producer p)
        {   
            await db.Add(p);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int Id)
        {
            var d = await db.GetById(Id);
            if (d == null)
                return View("NotFound");
            return View(d);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id,[Bind("Id,ProfilePictureUrl,FullName,Bio")] Producer p)
        {
            if (Id == p.Id)
            {
                await db.Update(Id, p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var a = await db.GetById(Id);
            if (a == null)
                return View("NotFound");

            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await db.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
