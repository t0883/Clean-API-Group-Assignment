using Domain.Models.Users;

namespace Infrastructure.Repository.Users
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> DeleteUserByEmail(User user);
    }
}
