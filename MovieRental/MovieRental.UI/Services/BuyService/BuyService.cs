using Blazored.LocalStorage;
using Blazored.Toast.Services;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Models;
using MovieRental.Domain;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MovieRental.UI.Services.BuyService
{
    public class BuyService : IBuyService
    {
        private const string URL = "https://localhost:7257/api/Sell";
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly IToastService _toastService;

        public BuyService(HttpClient httpClient, ILocalStorageService localStorageService, IToastService toastService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _toastService = toastService;
        }
        public async Task<bool> BuyMovie(int movieId)
        {
            string token = await  _localStorageService.GetItemAsync<string>("token");
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

        public async Task<List<MovieDto>> GetMyBoughtMovies()
        {
            string token = await _localStorageService.GetItemAsync<string>("token");
            string urlSell = URL;

            var request = new HttpRequestMessage(HttpMethod.Get, urlSell);
            request.Headers.Add("Authorization", "bearer " + token);
            
            var response = await _httpClient.SendAsync(request);
            var movies =  await response.Content.ReadFromJsonAsync<List<MovieDto>>();
            
            return movies;
        }
    }
}
