using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.Features.Sell.Requests.Queries;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Sell.Handlers.Queries
{
    public class GetBoughtMoviesRequestHandler : IRequestHandler<GetBoughMoviesRequest, List<MovieDto>>
    {

        private readonly ISellRepository _sellRepository;
        private readonly IMapper _mapper;

        public GetBoughtMoviesRequestHandler(ISellRepository sellRepository, IMapper mapper)
        {
            _sellRepository = sellRepository;
            _mapper = mapper;
        }


        public async Task<List<MovieDto>> Handle(GetBoughMoviesRequest request, CancellationToken cancellationToken)
        {
            var movies = await _sellRepository.GetBoughtMovies(request.Id);
            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
