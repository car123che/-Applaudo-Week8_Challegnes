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
    public class MockSellRepository
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

        public static List<Sell> Sells = new List<Sell>
            {
                new Sell{ Id = 1, MovieId = Movies[0].Id, UserId = Users[0].Id, Movie = Movies[0], User = Users[0]},
                new Sell{ Id = 2, MovieId = Movies[1].Id, UserId = Users[1].Id, Movie = Movies[1], User = Users[1]}
            };

        public static Mock<ISellRepository> GetSellRepositoryBougthMovies()
        {

            var mockRepo = new Mock<ISellRepository>();

            // Agregar una
            mockRepo.Setup(r => r.GetBoughtMovies(It.IsAny<int>())).ReturnsAsync((int UserId) =>
            {
                List<Movie> myBoughtMovies = new List<Movie>();

                foreach (var sell in Sells)
                {
                    if (sell.UserId == UserId)
                        myBoughtMovies.Add(sell.Movie);
                }

                return myBoughtMovies;

            });
            return mockRepo;
        }


        public static Mock<ISellRepository> GetSellRepositorySell()
        {

            var mockRepo = new Mock<ISellRepository>();

            // Vender
            mockRepo.Setup(r => r.Sell(It.IsAny<Sell>())).ReturnsAsync((Sell Sell) =>
            {
                Movie sellMovie = new Movie();
                foreach (var movie in Movies)
                {
                    if(movie.Id == Sell.MovieId)
                        sellMovie = movie;
                }
                sellMovie.Stock = sellMovie.Stock - 1;

                User userMovie = new User();
                foreach (var user in Users)
                {
                    if (user.Id == Sell.UserId)
                        userMovie = user;
                }

                var sell = new Sell() { Id = Sells.Count, MovieId = Sell.MovieId, UserId = Sell.UserId, Movie = sellMovie, User = userMovie };
                Sells.Add(sell);
             

                return sell;

            });
            return mockRepo;
        }

    }
}
