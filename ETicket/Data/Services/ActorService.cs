using ETicket.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext db;
        public ActorService(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Actor actor)
        {
            db.Actors.Add(actor);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var r=await db.Actors.FirstOrDefaultAsync(x => x.Id == Id); 
             db.Actors.Remove(r);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var d=await db.Actors.ToListAsync();
            return d;
        }

        public async Task<Actor> GetById(int Id)
        {
            var r=await db.Actors.FirstOrDefaultAsync(n => n.Id == Id);
            return r;
        }

        public async Task<Actor> Update(int Id, Actor newActor)
        {
            db.Update(newActor);
            await db.SaveChangesAsync();
            return newActor;
        }
    }
}
