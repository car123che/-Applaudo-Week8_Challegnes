using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Pesistence.Contracts
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
    }
}
