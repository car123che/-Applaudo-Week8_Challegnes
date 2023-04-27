using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Tag.Handlers.Command;
using MovieRental.Application.Features.Tag.Handlers.Queries;
using MovieRental.Application.Features.Tag.Requests.Command;
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

namespace MovieRental.Application.UnitTests.Tags.Command
{
    public class CreateTagCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITagRepository> _mockRepo;
        private readonly CreateTagDto _tagDto;
        private readonly CreateTagCommandHandler _handler;
        public CreateTagCommandHandlerTests()
        {
            _mockRepo = MockTagRepository.GetTagRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateTagCommandHandler(_mockRepo.Object, _mapper);

            _tagDto = new CreateTagDto
            {
                Name = "Test"
            };

        }

        [Fact]
        public async Task CreateTagCommand()
        {

            var result = await _handler.Handle(new CreateTagCommand() { TagDto = _tagDto}, CancellationToken.None);

            result.ShouldBeOfType<int>();
            MockTagRepository.Tags.Count.ShouldBe(3);
        }


    }
}
