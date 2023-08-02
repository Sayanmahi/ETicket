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

        public async Task AddNewMovie(NewMovieVm vm)
        {
            var n = new Movie();
            n.Name=vm.Name;
            n.Description=vm.Description;
            n.Price=vm.Price;
            n.ImageUrl=vm.ImageUrl;
            n.CinemaId=vm.CinemaId;
            n.StartDate=vm.StartDate;
            n.EndDate=vm.EndDate;
            n.MovieCategory=vm.MovieCategory;
            n.ProducerId=vm.ProducerId;
            await db.Movies.AddAsync(n);
            await db.SaveChangesAsync();

            //Add MovieActors
            foreach(var d in vm.ActorIds)
            {
                var s = new Actor_Movie();
                s.MovieId = n.Id;
                s.ActorId = d;
                await db.Actor_Movies.AddAsync(s);
                await db.SaveChangesAsync();
            }
            
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

        public async Task UpdateMovie(NewMovieVm vm)
        {
            var dp=await db.Movies.FirstOrDefaultAsync(n=> n.Id == vm.Id);
            if (dp != null)
            {
                dp.Name = vm.Name;
                dp.Description = vm.Description;
                dp.Price = vm.Price;
                dp.ImageUrl = vm.ImageUrl;
                dp.CinemaId = vm.CinemaId;
                dp.StartDate = vm.StartDate;
                dp.EndDate = vm.EndDate;
                dp.MovieCategory = vm.MovieCategory;
                dp.ProducerId = vm.ProducerId;
                await db.SaveChangesAsync();
            }
            //Remove existings actors related to this movie
            var existing=db.Actor_Movies.Where(n =>n.MovieId== vm.Id).ToList(); 
             db.Actor_Movies.RemoveRange(existing);
            await db.SaveChangesAsync();
            //Add MovieActors
            foreach (var d in vm.ActorIds)
            {
                var s = new Actor_Movie();
                s.MovieId = dp.Id;
                s.ActorId = d;
                await db.Actor_Movies.AddAsync(s);
                await db.SaveChangesAsync();
            }
        }
    }
}
