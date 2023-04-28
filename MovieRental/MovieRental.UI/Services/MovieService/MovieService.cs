using MovieRental.Application.DTOs.Movie;

namespace MovieRental.UI.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _client;
        private const string URL = "https://localhost:7257/api/Movie";

        public MovieService(HttpClient client)
        {
            _client = client;
        }

        public async Task<MovieDto> GeMovieDetails(int id)
        {
            string GetMovieUrl = URL + "/" + id;

            var movie = await _client.GetFromJsonAsync<MovieDto>(GetMovieUrl);

            if (movie == null)
                movie = new MovieDto();

            return movie;
        }

        public async Task<List<MovieDto>> GetAllMovies()
        {
            var movies = await _client.GetFromJsonAsync<IEnumerable<MovieDto>>(URL);

            if (movies == null)
                movies = new List<MovieDto>();

            return (List<MovieDto>)movies;
        }

        public async Task<List<MovieDto>> GetOrderedMovies()
        {
            const string UrlOrderedMovies = "https://localhost:7257/api/MovieTag";
            var movies = await _client.GetFromJsonAsync<IEnumerable<MovieDto>>(UrlOrderedMovies);
            if (movies == null)
                movies = new List<MovieDto>();

            return (List<MovieDto>)movies;
        }

        public async Task<List<MovieDto>> GetMoviesByTag(int TagId)
        {
            string UrlMoviesByTag = "https://localhost:7257/api/MovieTag/MoviesByTag/" + TagId;
            var movies = await _client.GetFromJsonAsync<IEnumerable<MovieDto>>(UrlMoviesByTag);
            if (movies == null)
                movies = new List<MovieDto>();

            return (List<MovieDto>)movies;
        }
    }
}
