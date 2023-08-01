using ETicket.Data.Base;
using ETicket.Data.ViewModel;
using ETicket.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Data.Services
{
    public class MovieService: EntityBaseRepository<Movie>,IMovieService
    {
        private readonly AppDbContext db;
        public MovieService(AppDbContext _db):base(_db)
        {
            db = _db;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var m =await db.Movies.Include(p => p.Cinema).Include(c => c.Producer).Include(k => k.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);
            return  m;
        }
        public async Task<NewMovieDropdownVM> GetNewMovieDropdown()
        {
            var d= new NewMovieDropdownVM();
            d.Actors = await db.Actors.OrderBy(n => n.FullName).ToListAsync();
            d.Cinemas = await db.Cinemas.OrderBy(n => n.Name).ToListAsync();
            d.Producers = await db.Producers.OrderBy(n => n.FullName).ToListAsync();
            return (d);
        }
    }
}
