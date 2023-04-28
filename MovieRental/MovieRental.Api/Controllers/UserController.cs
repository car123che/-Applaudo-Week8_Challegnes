using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.DTOs.User;
using MovieRental.Application.Features.Movie.Requests.Command;
using MovieRental.Application.Features.Movie.Requests.Queries;
using MovieRental.Application.Features.Tag.Requests.Command;
using MovieRental.Application.Features.User.Requests.Command;
using MovieRental.Application.Features.User.Requests.Queries;
using MovieRental.Application.Models;
using MovieRental.Domain;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UserController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        // GET: api/<UserController>
        [HttpGet, Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _mediator.Send(new GetUserListRequest());
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserRequest() { Id = id});
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost, Authorize(Roles = "admin")]
        public async Task<ActionResult> Post([FromBody] CreateUserDto userDto)
        {
            userDto.Password = EncripPassword(userDto.Password);
            var command = new CreateUserCommand() { UserDto= userDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            var command = new UpdateUserCommand() { UserDto = userDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<UserController>/role
        [HttpPut("role/{id}/{role}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> ChangeRole(int id, int role)
        {
            var command = new ChangeUserRoleCommand() { UserId = id, RoleId = role };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDetail loginDetail)
        {
            var user = await _mediator.Send(new UserExistsRequest() { Email = loginDetail.Email});
            var passwordSended = EncripPassword(loginDetail.Password);
            if (user.Password !=  passwordSended)
                return BadRequest("Wrong Password");

            //Create JWT
            string token = CreateToken(user);

            return Ok(token);
        }


        private string EncripPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hashValue = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashValue.Length; i++)
                {
                    sb.Append(hashValue[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }


        private string CreateToken(UserDto user)
        {
            var role = user.Role == 1 ? "admin" : "user";
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value));
            

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
