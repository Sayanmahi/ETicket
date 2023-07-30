using ETicket.Data.Base;
using ETicket.Models;

namespace ETicket.Data.Services
{
    public interface IMovieService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
    }
}
