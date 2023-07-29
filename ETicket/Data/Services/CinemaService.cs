using ETicket.Data.Base;
using ETicket.Models;

namespace ETicket.Data.Services
{
    public class CinemaService:EntityBaseRepository<Cinema>,ICinemaService
    {
        public CinemaService(AppDbContext db):base(db)
        {            
        }
    }
}
