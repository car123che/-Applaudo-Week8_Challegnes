using MediatR;
using MovieRental.Application.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Tag.Requests.Command
{
    public class CreateTagCommand : IRequest<int>
    {
        public CreateTagDto TagDto { get; set; }
    }
}
