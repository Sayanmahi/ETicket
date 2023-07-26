using ETicket.Models;

namespace ETicket.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int Id);
        Task Add(Actor actor);
        Task<Actor> Update(int Id, Actor newActor);
        Task Delete(int Id);
    }
}
