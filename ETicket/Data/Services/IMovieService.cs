using ETicket.Data.Base;
using ETicket.Data.ViewModel;
using ETicket.Models;

namespace ETicket.Data.Services
{
    public interface IMovieService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdown();
        Task AddNewMovie(NewMovieVm vm);
        Task UpdateMovie(NewMovieVm vm);

    }
}
