using ETicket.Data.Base;
using ETicket.Models;

namespace ETicket.Data.Services
{
    public class ProducerService:EntityBaseRepository<Producer>,IProducerService
    {

        public ProducerService(AppDbContext _db):base(_db)
        {
            
        }
    }
}
