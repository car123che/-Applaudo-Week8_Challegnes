using AutoMapper;
using MediatR;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.Movie.Requests.Command;
using MovieRental.Application.Features.MovieTag.Requests.Command;
using MovieRental.Application.Features.Sell.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.MovieTag.Handlers.Command
{
    public class DeleteMovieTagCommandHandler : IRequestHandler<DeleteMovieTagCommand, Unit>
    {

        private readonly IMovieTagRepository _movieTagRepository;
        private readonly IMapper _mapper;

        public DeleteMovieTagCommandHandler(IMovieTagRepository movieTagRepository, IMapper mapper)
        {
            _movieTagRepository = movieTagRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteMovieTagCommand request, CancellationToken cancellationToken)
        {
            var movieTag = _mapper.Map<MovieRental.Domain.MovieTag>(request.MovieTagDto);
            await _movieTagRepository.Delete(movieTag);

            return Unit.Value;
        }
    }
}
