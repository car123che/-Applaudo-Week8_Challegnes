using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Pesistence.Contracts
{
    public interface ISellRepository
    {
        Task<Sell> Sell(Sell entity);
        Task<bool> UserExists(int id);
        Task<bool> MovieExists(int id);
        Task<bool> MovieInStock(int id);
        Task<IReadOnlyList<Movie>> GetBoughtMovies(int id);

    }
}
