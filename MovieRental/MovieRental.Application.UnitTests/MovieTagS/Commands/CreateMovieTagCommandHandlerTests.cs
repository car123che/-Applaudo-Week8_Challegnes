using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.MovieTag;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.MovieTag.Handlers.Command;
using MovieRental.Application.Features.MovieTag.Requests.Command;
using MovieRental.Application.Features.Tag.Handlers.Command;
using MovieRental.Application.Features.Tag.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Application.Profiles;
using MovieRental.Application.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.MovieTag.Commands
{
    public class CreateMovieTagCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieTagRepository> _mockRepo;
        private readonly MovieTagDto _movietagDto;
        private readonly CreateMovieTagCommandHandler _handler;
        public CreateMovieTagCommandHandlerTests()

        {
            _mockRepo = MockMovieTagRepository.GetMovieTagRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateMovieTagCommandHandler(_mockRepo.Object, _mapper);

            _movietagDto = new MovieTagDto
            {
                MovieId = 2,
                TagId = 1
            };

        }


        //[Fact]
        public async Task CreateMovieTagCommand()
        {

            var result = await _handler.Handle(new CreateMovieTagCommand() { MovieTagDto = _movietagDto }, CancellationToken.None);

            result.ShouldBeOfType<int>();
            MockTagRepository.Tags.Count.ShouldBe(3);
        }


    }
}
