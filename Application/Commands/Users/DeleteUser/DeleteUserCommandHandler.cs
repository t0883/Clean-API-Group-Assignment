using Domain.Models.Users;
using Infrastructure.Repository.Users;
using MediatR;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User userToDelete = new User { Email = request.User.Email, Password = request.User.Password, Username = request.User.Username };

            await _userRepository.DeleteUserByEmail(userToDelete);

            return await Task.FromResult(userToDelete);
        }
    }
}
