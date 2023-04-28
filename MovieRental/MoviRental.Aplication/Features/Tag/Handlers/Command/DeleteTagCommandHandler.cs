using AutoMapper;
using MediatR;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.Tag.Requests.Command;
using MovieRental.Application.Features.User.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Tag.Handlers.Command
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Unit>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public DeleteTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.Get(request.Id);

            if (tag == null)
                throw new NotFoundException(nameof(tag), request.Id);

            await _tagRepository.Delete(tag);

            return Unit.Value;
        }
    }
}
