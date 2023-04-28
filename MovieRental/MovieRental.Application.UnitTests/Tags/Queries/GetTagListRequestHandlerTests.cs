using AutoMapper;
using Moq;
using MovieRental.Application.DTOs.Tag;
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

namespace MovieRental.Application.UnitTests.Tags.Queries
{
    public class GetTagListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITagRepository> _mockRepo;
        public GetTagListRequestHandlerTests()
        {
            _mockRepo = MockTagRepository.GetTagRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetTagListTest()
        {
            var handler = new GetTagListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetTagListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TagDto>>();

            result.Count<TagDto>().ShouldBe(2);
        }

    }
}
