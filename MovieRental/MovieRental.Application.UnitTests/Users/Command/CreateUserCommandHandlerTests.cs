using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.DTOs.User;
using MovieRental.Application.Features.Tag.Handlers.Command;
using MovieRental.Application.Features.Tag.Requests.Command;
using MovieRental.Application.Features.User.Handlers.Command;
using MovieRental.Application.Features.User.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Application.Profiles;
using MovieRental.Application.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Users.Command
{
    public class CreateUserCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly CreateUserDto _userDto;
        private readonly CreateUserCommandHandler _handler;
        public CreateUserCommandHandlerTests()
        {
            _mockRepo = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateUserCommandHandler(_mockRepo.Object, _mapper);

            _userDto = new CreateUserDto
            {
                Name = "Test",
                Email = "car123che@gmail.com",
                Age = 22,
                Password = "siu",
                Phone = "12343241324",
                Role = 2
            };

        }

        [Fact]
        public async Task CreateTagCommand()
        {

            var result = await _handler.Handle(new CreateUserCommand() { UserDto = _userDto }, CancellationToken.None);

            result.ShouldBeOfType<int>();
            MockUserRepository.Users.Count.ShouldBe(3);
        }
    }
}
