using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Movie.Requests.Queries
{
    public class GetMovieListRequest : IRequest<IEnumerable<MovieDto>>
    {
    }
}
