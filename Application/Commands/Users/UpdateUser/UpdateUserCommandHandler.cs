using Domain.Models.Users;
using Infrastructure.Repository.Users;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.UserToUpdate.Password);

            User userToUpdate = new User { Email = request.UserToUpdate.Email, Password = hashedPassword, Username = request.UserToUpdate.Username };

            var result = await _userRepository.UpdateUser(userToUpdate);

            return await Task.FromResult(result);

        }
    }
}
