using Blazored.LocalStorage;
using Blazored.Toast.Services;
using MovieRental.Application.DTOs.Movie;
using System.Net.Http;

namespace MovieRental.UI.Services.RentService
{
    public class RentService : IRentService
    {
        private const string URL = "https://localhost:7257/api/Rent";
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly IToastService _toastService;

        public RentService(HttpClient httpClient, ILocalStorageService localStorageService, IToastService toastService)
        {

            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _toastService = toastService;
        }

        public async Task<List<MovieDto>> GetMyRentedMovies()
        {
            string token = await _localStorageService.GetItemAsync<string>("token");
            string urlSell = URL;

            var request = new HttpRequestMessage(HttpMethod.Get, urlSell);
            request.Headers.Add("Authorization", "bearer " + token);

            var response = await _httpClient.SendAsync(request);
            var movies = await response.Content.ReadFromJsonAsync<List<MovieDto>>();

            return movies;
        }

        public async Task<bool> RentMovie(int movieId)
        {
            string token = await _localStorageService.GetItemAsync<string>("token");
            string urlSell = URL + "/" + movieId;

            var request = new HttpRequestMessage(HttpMethod.Post, urlSell);
            request.Headers.Add("Authorization", "bearer " + token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                _toastService.ShowSuccess("Movie Rented Successfully");
                return true;
            }
            else
            {
                _toastService.ShowError("Error while renting the movie");
                return false;
            }
        }

        public async Task<bool> ReturnMovie(int movieId)
        {
            string token = await _localStorageService.GetItemAsync<string>("token");
            string urlSell = URL + "/" + movieId;

            var request = new HttpRequestMessage(HttpMethod.Delete, urlSell);
            request.Headers.Add("Authorization", "bearer " + token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                _toastService.ShowSuccess("Movie Returned Successfully");
                return true;
            }
            else
            {
                _toastService.ShowError("Error while returning the movie");
                return false;
            }
        }
    }
}
