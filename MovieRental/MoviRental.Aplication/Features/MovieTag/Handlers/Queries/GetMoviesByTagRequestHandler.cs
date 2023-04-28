using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.MovieTag.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.MovieTag.Handlers.Queries
{
    public class GetMoviesByTagRequestHandler : IRequestHandler<GetMoviesByTagRequest, IEnumerable<MovieDto>>
    {
        private readonly IMovieTagRepository _movieTagRepository;
        private readonly IMapper _mapper;

        public GetMoviesByTagRequestHandler(IMovieTagRepository movieTagRepository, IMapper mapper)
        {
            _movieTagRepository = movieTagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetMoviesByTagRequest request, CancellationToken cancellationToken)
        {
            var movies= await _movieTagRepository.GetMoviesByTag(request.TagId);
            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
