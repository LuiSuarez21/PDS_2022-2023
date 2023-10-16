using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByUsername(string username);

        public Task<User> GetUserLogin(string username, string password);

        public Task<bool> CreateUser(User user);

        public Task<bool> UpdateUser(User user);

        public Task<bool> DeleteUser(int id, DateTime lastUpdate);

        public Task<User> GetUser(int id);

        public Task<IEnumerable<User>> GetAllUsers();
    }
}