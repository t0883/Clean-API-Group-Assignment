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
                bool uniqueEmail = await IsEmailUnique(user);

                if (!uniqueEmail)
                {
                    throw new Exception("An emailadress is registered to another user. Please try another emailadress.");
                }

                var result = _sqlServer.Users.Add(user);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw;
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

        public async Task<bool> IsEmailUnique(User user)
        {
            try
            {
                return !await _sqlServer.Users.AnyAsync(Users => Users.Email == user.Email);
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"An error occured while getting {user.Email}", ex.Message);
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                var UserToUpdate = await _sqlServer.Users.Where(e => e.Email == user.Email).FirstOrDefaultAsync();

                if (UserToUpdate == null)
                {
                    throw new ArgumentException($"There is no user with email {user.Email} in the database");
                }

                UserToUpdate.Username = user.Username;
                UserToUpdate.Password = user.Password;
                UserToUpdate.Email = user.Email;

                _sqlServer.Users.Update(UserToUpdate);

                _sqlServer.SaveChanges();

                return await Task.FromResult(UserToUpdate);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
