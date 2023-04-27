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
    public class GetUserListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepo;
        public GetUserListRequestHandlerTests()
        {
            _mockRepo = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUserListTest()
        {
            var handler = new GetUserListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetUserListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<UserDto>>();

            result.Count<UserDto>().ShouldBe(2);
        }
    }
}
