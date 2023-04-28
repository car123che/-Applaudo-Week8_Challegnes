using MediatR;
using MovieRental.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.User.Requests.Command
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UserDto UserDto { get; set; }
    }
}
