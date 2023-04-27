using Microsoft.EntityFrameworkCore;
using MovieRental.Application.Models;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieRental.Persistence.Repositories
{
    public class MovieTagRepository : IMovieTagRepository
    {
        private readonly MovieRentalDbContext _dbContext;

        public MovieTagRepository(MovieRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieTag> Add(MovieTag entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(MovieTag entity)
        {
            await _dbContext.Database
                .ExecuteSqlRawAsync($"Delete from MovieTags  WHERE MovieId = {entity.MovieId} and TagId = {entity.TagId}");
            await _dbContext.SaveChangesAsync();
        }

        public async  Task<List<Movie>> GetMoviesOrdered()
        {
            var movies = await _dbContext.Movies.OrderBy(q => q.Title).ToListAsync();
            return movies;
        }

        public async Task<List<Tag>> GetMovieTags(int id)
        {
            var tags = await _dbContext.MovieTags.Include(q => q.Movie).Where(q => q.MovieId == id)
                                .Select(q => new Tag
                                {
                                    Id = q.TagId,
                                    Name = q.Tag.Name
                                }).ToListAsync();

            return tags;
        }
    }
}
