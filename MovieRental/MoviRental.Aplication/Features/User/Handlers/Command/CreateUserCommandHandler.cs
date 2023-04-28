using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.User.Validator;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async  Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UserDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult, nameof(request.UserDto)); 

            var user = _mapper.Map<MovieRental.Domain.User>(request.UserDto); //map from the DTO to the domain type
            user = await _userRepository.Add(user);


            return user.Id;
        }
    }
}
