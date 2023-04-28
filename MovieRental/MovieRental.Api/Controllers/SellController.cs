using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Sell;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Sell.Requests.Command;
using MovieRental.Application.Features.Sell.Requests.Queries;
using MovieRental.Application.Features.Tag.Requests.Command;
using System.Data;
using System.Security.Claims;

namespace MovieRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SellController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("{movieId}"), Authorize(Roles = "admin,user")]
        public async Task<ActionResult> Post(int movieId)
        {
            var sellDto = new SellDto { 
                MovieId = movieId ,
                SellDate = DateTime.Now,
                Details = "Movie Rental Sell",
                UserId = GetMyId()
            };

            Console.WriteLine("MoveId: " + sellDto.MovieId);
            Console.WriteLine("UserId: " + sellDto.UserId);

            var command = new SellCommand() { SellDto = sellDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet, Authorize(Roles = "admin,user")]
        public async Task<ActionResult<List<MovieDto>>> Get()
        {
            var movies = await _mediator.Send(new GetBoughMoviesRequest{ Id = GetMyId()});
            return Ok(movies);
        }



        private int GetMyId()
        {
            var userId = string.Empty;
            var role = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid);

                role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            return Int32.Parse(userId);
        }

    }
}
