using ETicket.Models;

namespace ETicket.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int Id);
        void Add(Actor actor);
        Actor Update(int Id, Actor newActor);
        void Delete(int Id);
    }
}
