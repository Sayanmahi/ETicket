using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService db;
        public CinemaController(ICinemaService _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            var d= await db.GetAll();   
            return View(d);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema c)
        { 
            await db.Add(c);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int Id)
        {
            var d = await db.GetById(Id);
            if (d == null)
                return View("NotFound");
            return View(d);
        }
        public async Task<IActionResult> Update(int id)
        {
            var d=await db.GetById(id);
            if (d == null)
                return View("NotFound");
            return View(d);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,[Bind("Id,Logo,Name,Description")]Cinema c)
        {
            await db.Update(id,c);
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
            await db.Delete(Id);


            return RedirectToAction(nameof(Index));
        }

    }
}
