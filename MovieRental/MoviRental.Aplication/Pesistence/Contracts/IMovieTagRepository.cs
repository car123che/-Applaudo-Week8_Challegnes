using MovieRental.Application.Models;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Pesistence.Contracts
{
    public interface IMovieTagRepository
    {
        Task<MovieTag> Add(MovieTag entity);
        Task Delete(MovieTag entity);
        Task<List<Tag>> GetMovieTags(int id);
        Task<List<Movie>> GetMoviesOrdered();
    }
}
