using MovieRental.Application.DTOs.Movie;

namespace MovieRental.UI.Services.RentService
{
    public interface IRentService
    {
        Task<bool> RentMovie(int movieId);
        Task<List<MovieDto>> GetMyRentedMovies();
        Task<bool> ReturnMovie(int movieId);
    }
}
