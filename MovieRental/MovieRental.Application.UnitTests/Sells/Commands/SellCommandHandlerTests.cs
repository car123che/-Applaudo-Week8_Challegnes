using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Sell;
using MovieRental.Application.Features.Sell.Handlers.Command;
using MovieRental.Application.Features.Sell.Handlers.Queries;
using MovieRental.Application.Features.Sell.Requests.Command;
using MovieRental.Application.Features.Sell.Requests.Queries;
using MovieRental.Application.Persistence.Infrastructure;
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

namespace MovieRental.Application.UnitTests.Sells.Commands
{
    public class SellCommandHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<ISellRepository> _mockRepo;
        private readonly Mock<IMovieRepository> _movieMockRepo;
        private readonly Mock<IEmailSender> _emailSender;

        int UserId = 1;
        public SellCommandHandlerTests()
        {
            _mockRepo = MockSellRepository.GetSellRepositorySell();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _movieMockRepo = MockMovieRepository.GetMovieRepository();
            _emailSender = MockEmailService.GetEmailServiceMock();
        }

        [Fact]
        public async Task SellTest()
        {
            var sellDto = new SellDto { MovieId = 2, UserId = 1 };

            var handler = new SellCommandHandler(_mockRepo.Object , _mapper, _movieMockRepo.Object, _emailSender.Object);

            var result = await handler.Handle(new SellCommand() {  SellDto = sellDto }, CancellationToken.None);

            result.ShouldBeOfType<List<int>>();
            MockSellRepository.Sells.Count.ShouldBe(3);

            Movie movieSell = new Movie();
            foreach (var movie in MockSellRepository.Movies)
            {
                if (movie.Id == sellDto.MovieId)
                    movieSell = movie;
            }

            movieSell.Stock.ShouldBe(49);

        }
    }
}
