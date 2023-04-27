using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Rent;
using MovieRental.Application.DTOs.Sell;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.Rent.Requests.Command;
using MovieRental.Application.Features.Sell.Requests.Command;
using MovieRental.Application.Models;
using MovieRental.Application.Persistence.Infrastructure;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Rent.Handlers.Command
{
    public class RentCommandHandler : IRequestHandler<RentCommand, int>
    {
        private readonly IRentRepository _rentRepository;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IEmailSender _emailSender;
        private readonly ISellRepository _sellRepository;

        public RentCommandHandler(IRentRepository rentRepository,
            IMapper mapper, IMovieRepository movieRepository,
            IEmailSender emailSender,
            ISellRepository sellRepository)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
            _emailSender = emailSender;
            _sellRepository = sellRepository;
        }

        public async Task<int> Handle(RentCommand request, CancellationToken cancellationToken)
        {
            //validar que usuario y pelicula existan
            await MovieRentValidations(request.RentDto);

            //registrar renta
            var rent = _mapper.Map<MovieRental.Domain.Rent>(request.RentDto); //map from the DTO to the domain type
            rent = await _rentRepository.Rent(rent);

            //restar uno al stock
            var movie = await _movieRepository.Get(request.RentDto.MovieId);
            movie.Stock = movie.Stock - 1;
            await _movieRepository.Update(movie);

            await SendEmail(movie.Title, movie.SalePrice);

            return rent.Id;
        }

        public async Task MovieRentValidations(RentDto rentDto)
        {
            var userExists = await _sellRepository.UserExists(rentDto.UserId);
            var movieExists = await _sellRepository.MovieExists(rentDto.MovieId);
            if (userExists == false || movieExists == false)
                throw new NotFoundException("User or movie not found");

            var movieInStock = await _sellRepository.MovieInStock(rentDto.MovieId);
            if (movieInStock == false)
                throw new MovieOutOfStockException("Movie Out of Stock");
        }

        public async Task SendEmail(string movie, double price)
        {
            var email = new Email
            {
                To = "car123che@gmail.com",
                Body = $"You have rent your movie: {movie}. Price: {price}. Enjoy it!",
                Subject = $"Movie{movie} Rented"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" --------------- ERROR AL ENVIAR CORREO  --------------------- ");
            }
        }
    }
}
