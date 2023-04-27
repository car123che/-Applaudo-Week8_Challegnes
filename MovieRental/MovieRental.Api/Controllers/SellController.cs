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

namespace MovieRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SellController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Authorize(Roles = "admin,user")]
        public async Task<ActionResult> Post([FromBody] SellDto sellDto)
        {
            var command = new SellCommand() { SellDto = sellDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}"), Authorize(Roles = "admin,user")]
        public async Task<ActionResult<List<MovieDto>>> Get(int id)
        {
            var movies = await _mediator.Send(new GetBoughMoviesRequest{ Id = id });
            return Ok(movies);
        }
    }
}
