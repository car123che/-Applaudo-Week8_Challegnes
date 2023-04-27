using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.Movie.Handlers.Queries;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Application.Profiles;
using MovieRental.Application.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Movies.Requests
{
    public class GetMovieRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieRepository> _mockRepo;
        int movieId = 1;

        public GetMovieRequestHandlerTests()
        {
            _mockRepo = MockMovieRepository.GetMovieRepository(movieId);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }







        [Fact]
        public async Task GetMovieTest()
        {

            var handler = new GetMovieRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetMovieRequest() { Id = movieId }, CancellationToken.None);

            result.ShouldBeOfType<MovieDto>();

            result.Title.ShouldBe("Preuga");
        }

    }
}
