using Application.Commands.Users.AddUser;
using Application.Commands.Users.UpdateUser;
using Application.Dtos;
using Application.Queries.Users.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addNewUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            if (!userDto.Email.Contains("@"))
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(new AddUserCommand(userDto)));
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpPut]
        [Route("updateUserByEmail")]
        public async Task<IActionResult> UpdateUserByEmail([FromBody] UserDto userDto)
        {
            if (!userDto.Email.Contains("@"))
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new UpdateUserCommand(userDto)));
        }

    }
}
