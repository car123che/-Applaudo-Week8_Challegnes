using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.Rent.Handlers.Queries;
using MovieRental.Application.Features.Rent.Requests.Queries;
using MovieRental.Application.Features.Sell.Handlers.Queries;
using MovieRental.Application.Features.Sell.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Application.Profiles;
using MovieRental.Application.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Rents.Requests
{
    public class GetRentedMoviesRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRentRepository> _mockRepo;
        int UserId = 1;
        public GetRentedMoviesRequestHandlerTests()
        {
            _mockRepo = MockRentRepository.GetRentRepositoryBougthMovies();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetRentedMoviesTest()
        {
            var handler = new GetRentedMoviesRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetRentedMoviesRequest() { UserId = UserId }, CancellationToken.None);

            result.ShouldBeOfType<List<MovieDto>>();

            result.Count<MovieDto>().ShouldBe(1);
        }
    }
}
