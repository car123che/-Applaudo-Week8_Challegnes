using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Sell.Handlers.Queries;
using MovieRental.Application.Features.Sell.Requests.Queries;
using MovieRental.Application.Features.Tag.Handlers.Queries;
using MovieRental.Application.Features.Tag.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Application.Profiles;
using MovieRental.Application.UnitTests.Mocks;
using MovieRental.Domain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Sells.Requests
{
    public class GetMyBoughtMoviesRequestHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<ISellRepository> _mockRepo;
        int UserId = 1;
        public GetMyBoughtMoviesRequestHandlerTests()
        {
            _mockRepo = MockSellRepository.GetSellRepositoryBougthMovies();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetBoughtMoviesTest()
        {
            var handler = new GetBoughtMoviesRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetBoughMoviesRequest() { Id = UserId}, CancellationToken.None);

            result.ShouldBeOfType<List<MovieDto>>();

            result.Count<MovieDto>().ShouldBe(1);
        }

    }
}
