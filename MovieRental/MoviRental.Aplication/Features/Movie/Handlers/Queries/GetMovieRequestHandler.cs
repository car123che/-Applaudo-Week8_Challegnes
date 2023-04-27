using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Movie.Handlers.Queries
{
    public class GetMovieRequestHandler : IRequestHandler<GetMovieRequest, MovieDto>
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieRequestHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(GetMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id);
            return _mapper.Map<MovieDto>(movie);
        }
    }
}
