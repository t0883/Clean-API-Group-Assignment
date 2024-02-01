using Application.Commands.Users.AddUser;
using Application.Commands.Users.DeleteUser;
using Application.Commands.Users.UpdateUser;
using Application.Dtos;
using Application.Queries.Users.GetAll;
using Domain.Models.Users;
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
            try
            {
                if (!userDto.Email.Contains("@"))
                {
                    return BadRequest("Email must contain @.");
                }
                return Ok(await _mediator.Send(new AddUserCommand(userDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                List<User> users = await _mediator.Send(new GetAllUsersQuery());

                if (users == null)
                {
                    throw new Exception("An error occured while getting users from the database.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        [Route("deleteUserByEmail")]
        public async Task<IActionResult> DeleteUserByEmail([FromBody] UserDto userDto)
        {
            try
            {
                await _mediator.Send(new DeleteUserCommand(userDto));

                return NoContent();
            }
            catch (Exception)
            {

                return NoContent();
            }

        }
        [HttpPut]
        [Route("updateUserByEmail")]
        public async Task<IActionResult> UpdateUserByEmail([FromBody] UserDto userDto)
        {
            try
            {

                if (!userDto.Email.Contains("@"))
                {
                    return BadRequest();
                }

                return Ok(await _mediator.Send(new UpdateUserCommand(userDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
