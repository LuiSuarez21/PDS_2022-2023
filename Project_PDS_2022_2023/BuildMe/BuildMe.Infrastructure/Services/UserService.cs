using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserGateway _userGateway;
        private readonly IPasswordService _passwordService;

        public UserService(ILogger<UserService> logger, IUserGateway userGateway, IPasswordService passwordService)
        {
            _logger = logger;
            _userGateway = userGateway;
            _passwordService = passwordService;
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                var user = await _userGateway.GetUser(id);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get User with id [{id}]");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var user = await _userGateway.GetAllUsers();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get all Users");
                throw;
            }
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserLogin(string username, string password)
        {
            var message = "Error when trying to login";
            try
            {
                var result = await _userGateway.GetUserLogin(username);

                if (result is null || string.IsNullOrEmpty(result.Password))
                {
                    throw new Exception(message);
                }

                var userValid = _passwordService.VerifyHashedPassword(result.Password, password);
                //bool userValid = true;

                if (!userValid)
                {
                    throw new Exception(message);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to create User");
                throw;
            }
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Password))
                {
                    throw new ArgumentNullException("Password cannot be empty");
                }

                var hashPassword = _passwordService.HashPassword(user.Password);
                
                user.Password = hashPassword;

                return await _userGateway.CreateUser(user); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to create User");
                throw;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var hashPassword = _passwordService.HashPassword(user.Password);
                    user.Password = hashPassword;
                }

                return await _userGateway.UpdateUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update User with id [{user.Id}]");
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id, DateTime lastUpdate)
        {
            try
            {
                return await _userGateway.DeleteUser(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete User with id [{id}]");
                throw;
            }
        }
    }
}
