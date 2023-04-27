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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RentController(IMediator mediator)
        {
            _mediator = mediator;
        }

       

        // GET api/<RentController>/5
        [HttpGet("{id}"), Authorize(Roles = "admin,user")]
        public async Task<ActionResult<List<MovieDto>>> Get(int id)
        {
            var movies = await _mediator.Send(new GetRentedMoviesRequest{ UserId = id});
            return Ok(movies);
        }

        // POST api/<RentController>
        [HttpPost , Authorize(Roles = "admin,user")]
        public async Task<ActionResult> Post([FromBody] RentDto rentDto)
        {
            var command = new RentCommand() { RentDto = rentDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        // DELETE api/<RentController>/5
        [HttpDelete, Authorize(Roles = "admin,user")]
        public async Task<ActionResult> Delete(RentDto rentDto)
        {
            var command = new ReturnCommand() { RentDto = rentDto };
            var response = await _mediator.Send(command);
            return Ok();
        }
    }
}
