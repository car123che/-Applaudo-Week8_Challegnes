using AutoMapper;
using MediatR;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.Tag.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Tag.Handlers.Command
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Unit>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public UpdateTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.Get(request.TagDto.Id);
            if (tag == null)
                throw new NotFoundException(nameof(tag), request.TagDto.Id);


            _mapper.Map(request.TagDto, tag);
            await _tagRepository.Update(tag);

            return Unit.Value;
        }
    }
}
