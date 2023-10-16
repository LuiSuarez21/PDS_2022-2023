using BuildMe.Application.Configurations;
using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;

namespace BuildMe.Infrastructure.Gateways
{
    public class UserGateway : IUserGateway
    {
        private readonly SQLSettings _sqlSettings;

        public UserGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Users WHERE id = { id }";

                var result = connection.Query<User>(query).FirstOrDefault();

                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Users";

                var result = connection.Query<User>(query).ToList();

                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserLogin(string username)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Users WHERE username = '{ username }'";

                var result = connection.Query<User>(query).FirstOrDefault();
        
                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                user.UserTypeId = user.CompanyId is null ? 2 : 3;

                var query = @$"EXEC UserInsert01 '{user.UserName}', '{user.Password}', {user.UserTypeId}, '{user.VAT}', '{user.Phone}', '{user.Address}', '{user.PostalCode}', '{user.Email}'";

                if (user.CompanyId != null)
                {
                    query += $", {user.CompanyId}";
                }

                var result = connection.Query<int>(query).FirstOrDefault();

                if (result != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                user.UserTypeId = user.CompanyId is null ? 2 : 3;

                var query = @$"EXEC UserUpdate01 {user.Id}, '{user.UserName}', '{user.Password}', {user.UserTypeId}, '{user.VAT}', '{user.Phone}', '{user.Address}', '{user.PostalCode}', '{user.Email}', '{user.LastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";
                
                if (user.CompanyId != null)
                {
                    query += $", {user.CompanyId}";
                }

                var result = connection.Query<int>(query).FirstOrDefault();

                if (result == 1)
                    return true;
                else 
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id, DateTime lastUpdate)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC UserDelete01 {id}, '{lastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

                var result = connection.Query<int>(query).FirstOrDefault();

                if (result == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}