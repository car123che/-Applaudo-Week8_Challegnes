using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Pesistence.Contracts
{
    public interface IRentRepository
    {
        Task<Rent> Rent(Rent entity);
        Task Return(Rent entity);
        Task<List<Movie>> GetRentedMovies(int userId);
    }
}
