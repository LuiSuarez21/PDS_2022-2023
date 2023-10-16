using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserTypeGateway _userTypeGateway;

        public UserTypeService(ILogger<UserService> logger, IUserTypeGateway userTypeGateway)
        {
            _logger = logger;
            _userTypeGateway = userTypeGateway;
        }

        public async Task<bool> CreateUserType(UserType userType)
        {
            try
            {
                return await _userTypeGateway.CreateUserType(userType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to create UserType");
                throw;
            }
        }

        public async Task<bool> UpdateUserType(UserType userType)
        {
            try
            {
                return await _userTypeGateway.UpdateUserType(userType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update UserType with id [{userType.Id}]");
                throw;
            }
        }

        public async Task<bool> DeleteUserType(int id, DateTime lastUpdate)
        {
            try
            {
                return await _userTypeGateway.DeleteUserType(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete UserType with id [{id}]");
                throw;
            }
        }

        public async Task<UserType> GetUserType(int id)
        {
            try
            {
                return await _userTypeGateway.GetUserType(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get UserType with id [{id}]");
                throw;
            }
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypes()
        {
            try
            {
                var userTypes = await _userTypeGateway.GetAllUserTypes();
                return userTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get all UserTypes");
                throw;
            }
        }
    }
}