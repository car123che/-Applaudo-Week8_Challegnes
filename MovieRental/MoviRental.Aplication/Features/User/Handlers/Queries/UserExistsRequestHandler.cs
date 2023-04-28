using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.User;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.User.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.User.Handlers.Queries
{
    public class UserExistsRequestHandler : IRequestHandler<UserExistsRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserExistsRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UserExistsRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.UserExists(request.Email);
            if (user == null) 
                throw new NotFoundException(nameof(user), 0);

            return _mapper.Map<UserDto>(user);
        }
    }
}
