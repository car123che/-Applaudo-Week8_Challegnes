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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly MovieRentalDbContext _dbContext;

        public UserRepository(MovieRentalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeUseRole(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> UserExists(string email)
        {
            var users = await _dbContext.Users.ToListAsync();
            User? user = null;

            foreach (var usuario in users)
            {
                if(usuario.Email == email)
                {
                    user = usuario;
                    break;
                }
            }

            return user;
        }
    }
}
