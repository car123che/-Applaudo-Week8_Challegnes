using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Models;

namespace MovieRental.UI.Services.UserService
{
    public interface IUserService
    {
        Task<bool> Login(LoginDetail loginDetail);

      
    }
}
