using MediatR;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.MovieTag.Requests.Queries
{
    public class GetMovieTagsRequest : IRequest<MovieTagDetails>
    {
        public int Id { get; set; }
    }
}
