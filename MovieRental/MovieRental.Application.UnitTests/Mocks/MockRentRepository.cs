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
    public class MockRentRepository
    {
        public static List<Movie> Movies = new List<Movie>
            {
                new Movie{ Id = 1, Title = "Preuga", Stock = 5, Availability = 1, Description = "test", Likes = 50, SalePrice = 100},
                new Movie{ Id = 2, Title = "Preuga2", Stock = 50, Availability = 1, Description = "test2", Likes = 5 , SalePrice = 25}
            };

        public static List<User> Users = new List<User>
            {
                new User{ Id = 1, Name = "Carlos", Age =22, Email = "car123che@gmail.com", Password="123", Phone = "12345678", Role = 2},
                new User{ Id = 2, Name = "Carlos2", Age =21, Email = "car122che@gmail.com", Password="1223", Phone = "123245678", Role = 2}
            };

        public static List<Rent> Rents = new List<Rent>
            {
                new Rent{ Id = 1, MovieId = Movies[0].Id, UserId = Users[0].Id, Movie = Movies[0], User = Users[0]},
                new Rent{ Id = 2, MovieId = Movies[1].Id, UserId = Users[1].Id, Movie = Movies[1], User = Users[1]}
            };

        public static Mock<IRentRepository> GetRentRepositoryBougthMovies()
        {

            var mockRepo = new Mock<IRentRepository>();

            // Agregar una
            mockRepo.Setup(r => r.GetRentedMovies(It.IsAny<int>())).ReturnsAsync((int UserId) =>
            {
                List<Movie> myBoughtMovies = new List<Movie>();

                foreach (var rent in Rents)
                {
                    if (rent.UserId == UserId)
                        myBoughtMovies.Add(rent.Movie);
                }

                return myBoughtMovies;

            });
            return mockRepo;
        }


    }
}
