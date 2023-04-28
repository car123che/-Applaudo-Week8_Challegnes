using MovieRental.Application.DTOs.Movie;

namespace MovieRental.UI.Services.BuyService
{
    public interface IBuyService
    {
        Task<bool> BuyMovie(int movieId);
        Task<List<MovieDto>> GetMyBoughtMovies();
    }
}
