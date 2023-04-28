using MediatR;
using MovieRental.Application.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.MovieTag.Requests.Queries
{
    public class GetMovieListOrderedRequest : IRequest<IEnumerable<MovieDto>>
    {
    }
}
