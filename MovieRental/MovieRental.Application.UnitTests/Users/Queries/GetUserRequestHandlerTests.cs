using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.DTOs.User;
using MovieRental.Application.Features.Tag.Handlers.Queries;
using MovieRental.Application.Features.Tag.Requests.Queries;
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

namespace MovieRental.Application.UnitTests.Users.Queries
{
    public class GetUserRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepo;
        int userId = 1;

        public GetUserRequestHandlerTests()
        {
            _mockRepo = MockUserRepository.GetUserRepository(userId);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUserTest()
        {

            var handler = new GetUserRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetUserRequest() { Id = userId }, CancellationToken.None);

            result.ShouldBeOfType<UserDto>();

            result.Name.ShouldBe("Carlos");
        }
    }
}
