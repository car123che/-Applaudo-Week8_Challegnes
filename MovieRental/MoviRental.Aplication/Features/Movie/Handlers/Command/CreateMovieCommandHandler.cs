using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie.Validators;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.Movie.Requests.Command;
using MovieRental.Application.Pesistence.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Movie.Handlers.Command
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }


        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMovieDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MovieDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult, nameof(request.MovieDto));

            var movie = _mapper.Map<MovieRental.Domain.Movie>(request.MovieDto); //map from the DTO to the domain type
            movie = await _movieRepository.Add(movie);


            return movie.Id;
        }
    }
}
