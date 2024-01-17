using Domain.Models.Users;

namespace Infrastructure.Repository.Users
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
    }
}
