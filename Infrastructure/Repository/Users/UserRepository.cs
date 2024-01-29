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

                bool uniqueUsername = await IsUserNameUnique(user);

                if (!uniqueUsername)
                {
                    throw new Exception("A username is already in use");
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
                User? userToDelete = await _sqlServer.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

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

        public async Task<bool> IsUserNameUnique(User user)
        {
            try
            {
                return !await _sqlServer.Users.AnyAsync(Users => Users.Username == user.Username);
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"An error occured while getting {user.Username}", ex.Message);
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

                if (UserToUpdate.Password != user.Password) { UserToUpdate.Password = user.Password; }

                if (UserToUpdate.Email != user.Email)
                {
                    bool isEmailUnique = await IsEmailUnique(user);
                    {
                        if (!isEmailUnique)
                        {
                            throw new Exception("Email is already in use by another user. Please use another email");
                        }

                        UserToUpdate.Email = user.Email;

                    }
                }

                if (UserToUpdate.Username != user.Username)
                {
                    bool isUsernameUnique = await IsUserNameUnique(user);

                    if (!isUsernameUnique)
                    {
                        throw new Exception("Username is already in use by another user. Please use another username");
                    }
                    UserToUpdate.Username = user.Username;

                }

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
