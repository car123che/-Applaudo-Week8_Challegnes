using MediatR;
using MovieRental.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.User.Requests.Queries
{
    public class UserExistsRequest: IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
