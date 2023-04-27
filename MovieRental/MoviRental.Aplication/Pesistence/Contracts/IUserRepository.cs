using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Pesistence.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task ChangeUseRole(User user);
        Task<User> UserExists(string email);
    }
}
