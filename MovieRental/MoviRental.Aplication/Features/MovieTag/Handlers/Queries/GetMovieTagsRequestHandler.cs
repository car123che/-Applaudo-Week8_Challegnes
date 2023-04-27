using AutoMapper;
using MediatR;
using MovieRental.Application.Exceptions;
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
    public class GetMovieTagsRequestHandler : IRequestHandler<GetMovieTagsRequest, MovieTagDetails>
    {
        private readonly IMovieTagRepository _movieTagRepository;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieTagsRequestHandler(IMovieTagRepository movieTagRepository
                                        , IMapper mapper
                                        , IMovieRepository movieRepository)
        {
            _movieTagRepository = movieTagRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<MovieTagDetails> Handle(GetMovieTagsRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id);

            if (movie == null)
                throw new NotFoundException(nameof(movie), request.Id);

            var movieTags = await _movieTagRepository.GetMovieTags(request.Id);

            var movieTagDetail = new MovieTagDetails {
                Id = request.Id,
                Title = movie.Title,
                Tags = movieTags
            };

            return movieTagDetail;
        }
    }
}
