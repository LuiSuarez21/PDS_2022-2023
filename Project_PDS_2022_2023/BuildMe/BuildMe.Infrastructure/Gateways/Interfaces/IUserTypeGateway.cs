using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface IUserTypeGateway
    {
        public Task<bool> CreateUserType(UserType userType);
        public Task<bool> UpdateUserType(UserType userType);
        public Task<bool> DeleteUserType(int id, DateTime lastUpdate);
        public Task<UserType> GetUserType(int id);
        public Task<IEnumerable<UserType>> GetAllUserTypes();
    }
}
