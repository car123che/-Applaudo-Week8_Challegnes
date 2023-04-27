using Moq;
using MovieRental.Application.DTOs.MovieTag;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Mocks
{
    public class MockMovieTagRepository
    {
        public static List<MovieRental.Domain.MovieTag> MovieTags = new List<MovieRental.Domain.MovieTag>
            {
                new MovieRental.Domain.MovieTag{ Id = 1, MovieId = 1, TagId = 2},
                new MovieRental.Domain.MovieTag{ Id = 2, MovieId = 1, TagId = 3}
            };



        public static Mock<IMovieTagRepository> GetMovieTagRepository()
        {

            var mockRepo = new Mock<IMovieTagRepository>();

            // Agregar una
            mockRepo.Setup(r => r.Add(It.IsAny<MovieRental.Domain.MovieTag>())).Returns((MovieRental.Domain.MovieTag movieTag) =>
            {
                movieTag.Id = MovieTags.Count + 1;
                MovieTags.Add(movieTag);

                return movieTag;

            });
            return mockRepo;
        }

    }

}
