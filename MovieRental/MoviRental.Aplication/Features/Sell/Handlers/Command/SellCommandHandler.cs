using AutoMapper;
using MediatR;
using MovieRental.Application.DTOs.Sell;
using MovieRental.Application.Exceptions;
using MovieRental.Application.Features.Sell.Requests.Command;
using MovieRental.Application.Features.Tag.Requests.Command;
using MovieRental.Application.Models;
using MovieRental.Application.Persistence.Infrastructure;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Sell.Handlers.Command
{
    public class SellCommandHandler : IRequestHandler<SellCommand, int>
    {
        private readonly ISellRepository _sellRepository;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IEmailSender _emailSender;

        public SellCommandHandler(ISellRepository sellRepository, 
            IMapper mapper, IMovieRepository movieRepository,
            IEmailSender emailSender)
        {
            _sellRepository = sellRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
            _emailSender = emailSender;
        }

        public async Task<int> Handle(SellCommand request, CancellationToken cancellationToken)
        {
            //validar que usuario y pelicula existan
            await MovieSellValidations(request.SellDto);

            //registrar venta
            var sell = _mapper.Map<MovieRental.Domain.Sell>(request.SellDto); //map from the DTO to the domain type
            sell = await _sellRepository.Sell(sell);

            //restar uno al stock
            var movie = await _movieRepository.Get(request.SellDto.MovieId);
            movie.Stock = movie.Stock - 1;
            await _movieRepository.Update(movie);

            await SendEmail(movie.Title, movie.SalePrice);

            return sell.Id;
        }

        public async Task MovieSellValidations(SellDto sellDto)
        {
            var userExists = await _sellRepository.UserExists(sellDto.UserId);
            var movieExists = await _sellRepository.MovieExists(sellDto.MovieId);
            if (userExists == false || movieExists == false)
                throw new NotFoundException("User or movie not found");

            var movieInStock = await _sellRepository.MovieInStock(sellDto.MovieId);
            if (movieInStock == false)
                throw new MovieOutOfStockException("Movie Out of Stock");
        }

        public async Task SendEmail(string movie, double price)
        {
            var email = new Email
            {
                To = "car123che@gmail.com",
                Body = $"You have receive your movie: {movie}. Price: {price}. Enjoy it!",
                Subject = $"Movie{movie} Bought"
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
