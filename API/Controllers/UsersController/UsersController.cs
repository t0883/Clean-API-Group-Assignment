using Application.Commands.Users.AddUser;
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
            return Ok(await _mediator.Send(new AddUserCommand(userDto)));
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

    }
}
