using MediatR;
using MovieRental.Application.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Movie.Requests.Command
{
    public class CreateMovieCommand : IRequest<int>
    {
        public CreateMovieDto MovieDto { get; set; }
    }
}
