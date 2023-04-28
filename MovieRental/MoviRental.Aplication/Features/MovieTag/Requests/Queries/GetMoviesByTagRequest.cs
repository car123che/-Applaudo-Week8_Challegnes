using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.MovieTag.Requests.Queries
{
    public class GetMoviesByTagRequest : IRequest<IEnumerable<MovieDto>>
    {
        public int TagId { get; set; }
    }
}
