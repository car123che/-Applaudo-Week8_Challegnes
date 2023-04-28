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
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Tags.Command
{
    public class DeleteTagCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITagRepository> _mockRepo;
        private readonly TagDto _tagDto;
        private readonly DeleteTagCommandHandler _handler;
        int tagId = 1;
        public DeleteTagCommandHandlerTests()
        {
            _mockRepo = MockTagRepository.GetTagRepositoryDelete();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteTagCommandHandler(_mockRepo.Object, _mapper);

            _tagDto = new TagDto
            {
                Id = tagId
            };

        }


       // [Fact]
        public async Task DeleteTagTest()
        {

            var handler = new DeleteTagCommandHandler(_mockRepo.Object, _mapper);

            var result =  handler.Handle(new DeleteTagCommand() { Id = tagId }, CancellationToken.None);

            MockTagRepository.Tags.Count.ShouldBe(1);
        }


    }

}
