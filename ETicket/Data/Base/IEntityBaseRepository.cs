using ETicket.Models;

namespace ETicket.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task Add(T entity);
        Task Update(int Id, T entity);
        Task Delete(int Id);
    }
}
