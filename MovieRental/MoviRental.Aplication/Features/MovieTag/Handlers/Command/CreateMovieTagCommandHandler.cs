using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Movie.Validators;
using MovieRental.Application.Features.MovieTag.Requests.Command;
using MovieRental.Application.Features.MovieTag.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.MovieTag.Handlers.Command
{
    public class CreateMovieTagCommandHandler : IRequestHandler<CreateMovieTagCommand, int>
    {
        private readonly IMovieTagRepository _movieTagRepository;
        private readonly IMapper _mapper;

        public CreateMovieTagCommandHandler(IMovieTagRepository movieTagRepository, IMapper mapper)
        {
            _movieTagRepository = movieTagRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateMovieTagCommand request, CancellationToken cancellationToken)
        {
         
            var movieTag = _mapper.Map<MovieRental.Domain.MovieTag>(request.MovieTagDto); //map from the DTO to the domain type
            movieTag = await _movieTagRepository.Add(movieTag);

            return movieTag.Id;
        }
    }
}
