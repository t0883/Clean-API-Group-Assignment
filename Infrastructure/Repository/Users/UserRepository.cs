using Domain.Models.Users;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServer _sqlServer;

        public UserRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                var result = _sqlServer.Users.Add(user);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw new ArgumentException($"An error occured while adding {user.Username}. Please check if {user.Username} doesnt already exist in the database.");
            }
        }

        public async Task<User> DeleteUserByEmail(User user)
        {
            try
            {
                User userToDelete = await _sqlServer.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

                if (userToDelete == null)
                {
                    throw new ArgumentException($"There is no user with {user.Email} in the database");
                }

                var result = _sqlServer.Users.Remove(userToDelete);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Users.ToListAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
