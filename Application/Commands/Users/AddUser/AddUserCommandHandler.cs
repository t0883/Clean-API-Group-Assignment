using Domain.Models.Users;
using Infrastructure.Repository.Users;
using MediatR;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            string hashedPassowrd = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);

            User userToCreate = new User { UserId = Guid.NewGuid(), Username = request.NewUser.Username, Email = request.NewUser.Email, Password = hashedPassowrd };

            await _userRepository.AddUser(userToCreate);

            return await Task.FromResult(userToCreate);
        }
    }
}
