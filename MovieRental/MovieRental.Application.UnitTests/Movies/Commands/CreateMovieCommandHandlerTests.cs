using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.Movie.Handlers.Command;
using MovieRental.Application.Features.Movie.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Application.Profiles;
using MovieRental.Application.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Movies.Commands
{
    public class CreateMovieCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieRepository> _mockRepo;
        private readonly CreateMovieDto _MovieDto;
        private readonly CreateMovieCommandHandler _handler;
        public CreateMovieCommandHandlerTests()
        {
            _mockRepo = MockMovieRepository.GetMovieRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateMovieCommandHandler(_mockRepo.Object, _mapper);

            _MovieDto = new CreateMovieDto
            {
                Title = "test",
                Availability = 1,
                Description = "des",
                Stock = 20,
                TrailerLink = "trailer",
                Likes = 11,
                Poster = "poster",
                SalePrice =200
            };

        }

        [Fact]
        public async Task CreateMovieCommand()
        {

            var result = await _handler.Handle(new CreateMovieCommand() { MovieDto = _MovieDto }, CancellationToken.None);

            result.ShouldBeOfType<int>();
            MockMovieRepository.Movies.Count.ShouldBe(3);
        }
    }
}
