using AutoMapper;
using MediatR;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.User.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.User.Handlers.Command
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(user), request.Id);

            await _userRepository.Delete(user);

            return Unit.Value;
        }
    }
}
