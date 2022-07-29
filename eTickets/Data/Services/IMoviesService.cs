using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services;

public interface IMoviesService : IEntityBaseRepository<Movie>
{
    Task<Movie> GetMovieByIdAsync(int id);
}