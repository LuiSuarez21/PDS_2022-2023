using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface IUserGateway
    {
        public Task<User> GetUserByUsername(string username);

        public Task<User> GetUserLogin(string username);

        public Task<bool> CreateUser(User user);

        public Task<bool> UpdateUser(User user);

        public Task<bool> DeleteUser(int id, DateTime lastUpdate);
        
        public Task<User> GetUser(int id);
        
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
