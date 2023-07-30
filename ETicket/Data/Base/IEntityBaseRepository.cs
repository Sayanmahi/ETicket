using ETicket.Models;
using System.Linq.Expressions;

namespace ETicket.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties);
        Task<T> GetById(int Id);
        Task Add(T entity);
        Task Update(int Id, T entity);
        Task Delete(int Id);
    }
}
