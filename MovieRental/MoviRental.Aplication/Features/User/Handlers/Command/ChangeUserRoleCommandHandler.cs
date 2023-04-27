using AutoMapper;
using MediatR;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.User.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.User.Handlers.Command
{
    public class ChangeUserRoleCommandHandler : IRequestHandler<ChangeUserRoleCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChangeUserRoleCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(user), request.UserId);

            user.Role = request.RoleId;

            await _userRepository.ChangeUseRole(user);
            return Unit.Value;  

        }
    }
}
