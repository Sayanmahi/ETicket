using ETicket.Data.Base;
using ETicket.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>,IActorService
    {
        
        public ActorService(AppDbContext _db):base(_db) { }
      
       
    }
}
