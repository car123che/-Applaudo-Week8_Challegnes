using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly MovieRentalDbContext _dbContext;

        public MovieRepository(MovieRentalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
