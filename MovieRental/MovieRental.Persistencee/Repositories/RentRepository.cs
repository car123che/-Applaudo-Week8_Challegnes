using Microsoft.EntityFrameworkCore;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Persistence.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly MovieRentalDbContext _dbContext;

        public RentRepository(MovieRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Movie>> GetRentedMovies(int userId)
        {
            var movies = await _dbContext.Rents.Include(q => q.Movie)
                        .Where(q => q.UserId == userId).Select(
                               q =>
                               new Movie
                               {
                                   Id = q.MovieId,
                                   Title = q.Movie.Title,
                                   Description = q.Movie.Description,
                                   Poster = q.Movie.Poster,
                                   Stock = q.Movie.Stock,
                                   TrailerLink = q.Movie.TrailerLink,
                                   SalePrice = q.Movie.SalePrice,
                                   Likes = q.Movie.Likes,
                                   Availability = q.Movie.Availability
                               }
                           ).ToListAsync();
            return movies;
        }

        public async Task<Rent> Rent(Rent entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Return(Rent entity)
        {
            // Devolver Pelicula
            await _dbContext.Database
                .ExecuteSqlRawAsync($"Delete from Rents WHERE MovieId = {entity.MovieId} and UserId = {entity.UserId}");
            // Salvar todos los cambios
            await _dbContext.SaveChangesAsync();
        }
    }
}
