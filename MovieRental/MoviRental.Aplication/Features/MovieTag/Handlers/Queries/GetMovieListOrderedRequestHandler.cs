using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.MovieTag.Requests.Queries;
using MovieRental.Application.Models;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.MovieTag.Handlers.Queries
{
    public class GetMovieListOrderedRequestHandler
        : IRequestHandler<GetMovieListOrderedRequest, IEnumerable<MovieDto>>
    {
        private readonly IMovieTagRepository _movieTagRepository;
        private readonly IMapper _mapper;

        public GetMovieListOrderedRequestHandler(IMovieTagRepository movieTagRepository, IMapper mapper)
        {
            _movieTagRepository = movieTagRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieDto>> Handle(GetMovieListOrderedRequest request, CancellationToken cancellationToken)
        {
            var moviesOrdered = await _movieTagRepository.GetMoviesOrdered();
            return _mapper.Map<List<MovieDto>>(moviesOrdered);
        }
    }
}
