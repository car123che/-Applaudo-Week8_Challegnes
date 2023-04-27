using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Tag.Handlers.Queries;
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

namespace MovieRental.Application.UnitTests.Tags.Queries
{
    public class GetTagRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITagRepository> _mockRepo;
        int tagId = 1;
        public GetTagRequestHandlerTests()
        {
            _mockRepo = MockTagRepository.GetTagRepository(tagId);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetTagTest()
        {
           
            var handler = new GetTagRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetTagRequest() { Id = tagId}, CancellationToken.None);

            result.ShouldBeOfType<TagDto>();

            result.Name.ShouldBe("Accion");
        }

    }
}
