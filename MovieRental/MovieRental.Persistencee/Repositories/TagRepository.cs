using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Persistence.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly MovieRentalDbContext _dbContext;

        public TagRepository(MovieRentalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
