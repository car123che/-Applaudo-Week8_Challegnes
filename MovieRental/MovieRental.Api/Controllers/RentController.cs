using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Rent;
using MovieRental.Application.DTOs.Sell;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Features.Rent.Requests.Command;
using MovieRental.Application.Features.Rent.Requests.Queries;
using MovieRental.Application.Features.Sell.Requests.Command;
using System.Data;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Api.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RentController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

       

        // GET api/<RentController>/5
        [HttpGet(""), Authorize(Roles = "admin,user")]
        public async Task<ActionResult<List<MovieDto>>> Get()
        {
            var movies = await _mediator.Send(new GetRentedMoviesRequest{ UserId = GetMyId()});
            return Ok(movies);
        }

        // POST api/<RentController>
        [HttpPost("{movieId}") , Authorize(Roles = "admin,user")]
        public async Task<ActionResult> Post(int movieId)
        {
            var rentDto = new RentDto
            {
                MovieId = movieId,
                UserId = GetMyId(),
                rentedDate = DateTime.Now,
                Comments = "Movie Rented",
                returnDate = DateTime.Now.AddMonths(1).ToString()
            };
            var command = new RentCommand() { RentDto = rentDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        // DELETE api/<RentController>/5
        [HttpDelete("{movieId}"), Authorize(Roles = "admin,user")]
        public async Task<ActionResult> Delete(int movieId)
        {
            var rentDto = new RentDto
            {
                MovieId = movieId,
                UserId = GetMyId(),
                rentedDate = DateTime.Now,
                Comments = "Movie Rented",
                returnDate = DateTime.Now.ToString()
            };
            var command = new ReturnCommand() { RentDto = rentDto };
            var response = await _mediator.Send(command);
            return Ok();
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
