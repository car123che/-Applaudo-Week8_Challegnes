using MediatR;
using MovieRental.Application.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.Rent.Requests.Queries
{
    public class GetRentedMoviesRequest: IRequest<IEnumerable<MovieDto>>
    {
        public int UserId { get; set; }
    }
}
