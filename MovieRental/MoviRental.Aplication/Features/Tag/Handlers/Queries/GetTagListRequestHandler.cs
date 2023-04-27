using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.DTOs.User;
using MovieRental.Application.Features.Tag.Requests.Queries;
using MovieRental.Application.Features.User.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Tag.Handlers.Queries
{
    public class GetTagListRequestHandler : IRequestHandler<GetTagListRequest, IEnumerable<TagDto>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagListRequestHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetTagListRequest request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.GetAll();
            return _mapper.Map<List<TagDto>>(tags);
        }
    }
}
