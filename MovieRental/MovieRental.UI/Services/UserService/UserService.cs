using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MovieRental.Application.Models;
using MovieRental.UI.Data;
using SendGrid;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MovieRental.UI.Services.UserService
{
    public class UserService : IUserService
    {
        private const string URL = "https://localhost:7257/api/User/login";
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _client;
        private readonly IToastService _toastService;
        public UserService(ILocalStorageService localStorageService, HttpClient client, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _client = client;
            _toastService = toastService;
        }

        public async Task<bool> Login(LoginDetail loginDetail)
        {
            string token = "";
            var response = await _client.PostAsJsonAsync<LoginDetail>(URL, loginDetail);
           
            if(response.IsSuccessStatusCode)
            {
                token = await response.Content.ReadAsStringAsync();
                await _localStorageService.SetItemAsync("token", token);
                _toastService.ShowSuccess("Welcome");
                return true;
            }
            else
            {
                _toastService.ShowError("Wrong User or Password");
                return false;
            }

        }

    }
}
