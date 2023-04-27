using MediatR;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Tag.Requests.Queries
{
    public class GetTagRequest : IRequest<TagDto>
    {
        public int Id { get; set; }
    }
}
