using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.Features.Movie.Requests.Command;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Features.Tag.Requests.Command;
using MovieRental.Application.Features.Tag.Requests.Queries;
using MovieRental.Application.Features.User.Requests.Command;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

      

        // GET api/<TagController>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDto>>>  Get()
        {
            var tags = await _mediator.Send(new GetTagListRequest());
            return Ok(tags);
        }

        // GET: api/<TagController>
        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> Get(int id)
        {
            var tag = await _mediator.Send(new GetTagRequest() { Id = id });
            return Ok(tag);
        }

        // POST api/<TagController>
        [HttpPost, Authorize(Roles = "admin")]
        public async Task<ActionResult> Post([FromBody] CreateTagDto tagDto)
        {
            var command = new CreateTagCommand() { TagDto = tagDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<TagController>/5
        [HttpPut("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> Put(int id, [FromBody] TagDto tagDto)
        {
            var command = new UpdateTagCommand() { TagDto = tagDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<TagController>/5
        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTagCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
