using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.Rent.Requests.Queries;
using MovieRental.Application.Persistence.Infrastructure;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Rent.Handlers.Queries
{
    public class GetRentedMoviesRequestHandler : IRequestHandler<GetRentedMoviesRequest, IEnumerable<MovieDto>>
    {
        private readonly IRentRepository _rentRepository;
        private readonly IMapper _mapper;

        public GetRentedMoviesRequestHandler(IRentRepository rentRepository,IMapper mapper)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MovieDto>> Handle(GetRentedMoviesRequest request, CancellationToken cancellationToken)
        {
            var movies = await _rentRepository.GetRentedMovies(request.UserId);
            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
