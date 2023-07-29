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
    }
}
