using MediatR;
using MovieRental.Application.DTOs.MovieTag;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.MovieTag.Requests.Command
{
    public class CreateMovieTagCommand : IRequest<int>
    {
        public MovieTagDto MovieTagDto { get; set; }
    }
}
