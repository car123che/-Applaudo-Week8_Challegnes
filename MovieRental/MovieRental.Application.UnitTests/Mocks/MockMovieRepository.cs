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
    public class MockMovieRepository
    {
        public static List<Movie> Movies = new List<Movie>
            {
                new Movie{ Id = 1, Title = "Preuga", Stock = 5, Availability = 1, Description = "test", Likes = 50},
                new Movie{ Id = 2, Title = "Preuga2", Stock = 50, Availability = 1, Description = "test2", Likes = 5 }
            };

        public static Mock<IMovieRepository> GetMovieRepository()
        {

            var mockRepo = new Mock<IMovieRepository>();

            // Obtener todas
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Movies);



            // Agregar una
            mockRepo.Setup(r => r.Add(It.IsAny<Movie>())).ReturnsAsync((Movie Movie) =>
            {
                Movies.Add(Movie);
                return Movie;
            });

            return mockRepo;
        }

        public static Mock<IMovieRepository> GetMovieRepository(int id)
        {

            var mockRepo = new Mock<IMovieRepository>();

            // Obtener una
            mockRepo.Setup(r => r.Get(id)).ReturnsAsync(Movies.FirstOrDefault(new Movie { Id = id }));

            return mockRepo;
        }

    }

}
