using BuildMe.Application.Configurations;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BuildMe.Infrastructure.Gateways
{
    public class UserTypeGateway : IUserTypeGateway
    {
        private readonly SQLSettings _sqlSettings;

        public UserTypeGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<bool> CreateUserType(UserType userType)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC UserTypeInsert01 '{userType.Description}'";

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

        public async Task<bool> UpdateUserType(UserType userType)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC UserTypeUpdate01 {userType.Id}, '{userType.Description}', {userType.Inactive}, '{userType.LastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

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

        public async Task<bool> DeleteUserType(int id, DateTime lastUpdate)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC UserTypeDelete01 {id}, '{lastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

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

        public async Task<UserType> GetUserType(int id)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM UserTypes WHERE id = {id}";

                var result = connection.Query<UserType>(query).FirstOrDefault();

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

        public async Task<IEnumerable<UserType>> GetAllUserTypes()
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM UserTypes";

                var result = connection.Query<UserType>(query).ToList();

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
    }
}