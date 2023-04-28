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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.UserDto.Id);
            if (user == null)
                throw new NotFoundException(nameof(user), request.UserDto.Id);


            _mapper.Map(request.UserDto, user);
            await _userRepository.Update(user);

            return Unit.Value;
        }
    }

}
