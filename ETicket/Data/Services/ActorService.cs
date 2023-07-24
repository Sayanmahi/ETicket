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
        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var d=await db.Actors.ToListAsync();
            return d;
        }

        public Actor GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int Id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
