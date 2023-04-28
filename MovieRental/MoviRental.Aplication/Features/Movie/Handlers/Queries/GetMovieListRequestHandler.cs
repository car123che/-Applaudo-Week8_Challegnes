using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Features.Tag.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Movie.Handlers.Queries
{
    public class GetMovieListRequestHandler : IRequestHandler<GetMovieListRequest, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieListRequestHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetMovieListRequest request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAll();
            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
