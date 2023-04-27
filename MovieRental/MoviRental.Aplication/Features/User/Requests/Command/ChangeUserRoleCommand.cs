using MediatR;
using MovieRental.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.User.Requests.Command
{
    public class ChangeUserRoleCommand: IRequest<Unit>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
