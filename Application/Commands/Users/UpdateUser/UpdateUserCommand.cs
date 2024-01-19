using Application.Dtos;
using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<User>
    {
        public UpdateUserCommand(UserDto userDto)
        {
            UserToUpdate = userDto;
        }

        public UserDto UserToUpdate { get; set; }
    }
}
