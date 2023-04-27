using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.MovieTag;
using MovieRental.Application.DTOs.Sell;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Features.MovieTag.Requests.Command;
using MovieRental.Application.Features.MovieTag.Requests.Queries;
using MovieRental.Application.Features.Sell.Requests.Command;
using MovieRental.Application.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTagController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieTagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MovieTagController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> Get()
        {
            var movies = await _mediator.Send(new GetMovieListOrderedRequest());
            return Ok(movies);
        }

        // GET api/<MovieTagController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieTagDetails>> Get(int id)
        {
            var movieTagDetail = await _mediator.Send(new GetMovieTagsRequest { Id = id});
            return Ok(movieTagDetail);
        }

        // POST api/<MovieTagController>
        [HttpPost, Authorize(Roles = "admin")]
        public async Task<ActionResult> Post([FromBody] MovieTagDto movieTagDto)
        {
            var command = new CreateMovieTagCommand() { MovieTagDto = movieTagDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        // DELETE api/<MovieTagController>/5
        [HttpDelete, Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete([FromBody] MovieTagDto movieTagDto)
        {
            var command = new DeleteMovieTagCommand() { MovieTagDto = movieTagDto };
            var response = await _mediator.Send(command);
            return Ok();
        }
    }
}
