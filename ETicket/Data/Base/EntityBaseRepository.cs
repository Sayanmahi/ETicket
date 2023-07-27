using ETicket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicket.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext db;
        public EntityBaseRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(T entity)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var d = await db.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);
            db.Set<T>().Remove(d);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var d = await db.Set<T>().ToListAsync();
            return d;
        }

        public async Task<T> GetById(int Id)
        {
            var d= await db.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);
            return d;
        }

        public async Task Update(int Id, T entity)
        {

            db.Update(entity);
            await db.SaveChangesAsync();

        }
    }
}
