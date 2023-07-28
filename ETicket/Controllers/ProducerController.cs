using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService db;
        public ProducerController(IProducerService _db)
        {
            db = _db;            
        }
        public async Task<IActionResult> Index()
        {
            var d = await db.GetAll(); ;
            return View(d);
        }
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
    }
}
