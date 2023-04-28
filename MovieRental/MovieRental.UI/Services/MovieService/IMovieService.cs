using MovieRental.Application.DTOs.Movie;

namespace MovieRental.UI.Services.MovieService
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMovies();
        Task<MovieDto> GeMovieDetails(int id);
    }
}
