using MediatR;
using MovieRental.Application.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.Sell.Requests.Queries
{
    public class GetBoughMoviesRequest: IRequest<List<MovieDto>>
    {
        public int Id { get; set; }
    }
}
