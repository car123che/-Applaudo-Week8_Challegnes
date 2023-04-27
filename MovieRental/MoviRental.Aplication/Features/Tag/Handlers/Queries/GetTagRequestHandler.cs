using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Tag.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Tag.Handlers.Queries
{
    public class GetTagRequestHandler : IRequestHandler<GetTagRequest, TagDto>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagRequestHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagDto> Handle(GetTagRequest request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.Get(request.Id);
            return _mapper.Map<TagDto>(tag);
        }
    }
}
