using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.User;
using MovieRental.Application.Features.User.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.User.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }

    }
}
