using MediatR;
using Moq;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Mocks
{
    public class MockUserRepository
    {
        public static List<User> Users = new List<User>
            {
                new User{ Id = 1, Name = "Carlos", Age =22, Email = "car123che@gmail.com", Password="123", Phone = "12345678", Role = 2},
                new User{ Id = 2, Name = "Carlos2", Age =22, Email = "car122che@gmail.com", Password="1223", Phone = "123245678", Role = 2}
            };

        public static Mock<IUserRepository> GetUserRepository()
        {
           
            var mockRepo = new Mock<IUserRepository>();

            // Obtener todas
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Users);

            

            // Agregar una
            mockRepo.Setup(r => r.Add(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                Users.Add(user);
                return user;
            });

            return mockRepo;
        }

        public static Mock<IUserRepository> GetUserRepository(int id)
        {

            var mockRepo = new Mock<IUserRepository>();

            // Obtener una
            mockRepo.Setup(r => r.Get(id)).ReturnsAsync(Users.FirstOrDefault(new User { Id = id}));

            return mockRepo;
        }

        

    }
}
