using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.User;
using MovieRental.Application.Features.Movie.Handlers.Queries;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Features.User.Handlers.Queries;
using MovieRental.Application.Features.User.Requests.Queries;
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
    public class GetMovieListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieRepository> _mockRepo;

        public GetMovieListRequestHandlerTests()
        {
            _mockRepo = MockMovieRepository.GetMovieRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetUserListTest()
        {
            var handler = new GetMovieListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetMovieListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<MovieDto>>();

            result.Count<MovieDto>().ShouldBe(2);
        }
    }
}
