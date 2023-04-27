using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Movie.Requests.Command;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Features.User.Requests.Command;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> Get()
        {
            var movies = await _mediator.Send(new GetMovieListRequest());
            return Ok(movies);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> Get(int id)
        {
            var movie = await _mediator.Send(new GetMovieRequest() { Id = id });
            return Ok(movie);
        }

        // POST api/<MovieController>
        [HttpPost, Authorize(Roles = "admin")]
        public async Task<ActionResult> Post([FromBody] CreateMovieDto movieDto)
        {
            var command = new CreateMovieCommand() { MovieDto = movieDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> Put(int id, [FromBody] MovieDto movieDto)
        {
            var command = new UpdateMovieCommand() { MovieDto = movieDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteMovieCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
