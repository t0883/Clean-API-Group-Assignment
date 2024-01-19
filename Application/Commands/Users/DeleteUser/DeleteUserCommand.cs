using Application.Dtos;
using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<User>
    {
        public DeleteUserCommand(UserDto user)
        {

            User = user;

        }

        public UserDto User { get; }

    }
}
