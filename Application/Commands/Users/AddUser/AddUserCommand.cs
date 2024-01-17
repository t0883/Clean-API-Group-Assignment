using Application.Dtos;
using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommand : IRequest<User>
    {
        public AddUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }

        public UserDto NewUser { get; }

    }
}
