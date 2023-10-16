using BuildMe.Application.Configurations;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BuildMe.Infrastructure.Gateways
{
    public class TaskGateway : ITaskGateway
    {
        private readonly SQLSettings _sqlSettings;

        public TaskGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<bool> CreateTask(_Task task)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC TaskInsert01 
{task.UserId}, 
'{task.Description}', 
{task.CityId}, 
'{task.DateStart:yyyy-MM-dd HH:mm:ss.fff}', 
'{task.DateEnd:yyyy-MM-dd HH:mm:ss.fff}', 
'{task.DateBiddingStart:yyyy-MM-dd HH:mm:ss.fff}', 
'{task.DateBiddingEnd:yyyy-MM-dd HH:mm:ss.fff}', 
{task.TaskStatusId}
";

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

        public async Task<bool> UpdateTask(_Task task)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC TaskUpdate01 
{task.Id}, 
{task.UserId},
'{task.Description}', 
{task.CityId}, 
'{task.DateStart:yyyy-MM-dd HH:mm:ss.fff}', 
'{task.DateEnd:yyyy-MM-dd HH:mm:ss.fff}', 
'{task.DateBiddingStart:yyyy-MM-dd HH:mm:ss.fff}', 
'{task.DateBiddingEnd:yyyy-MM-dd HH:mm:ss.fff}', 
{task.TaskStatusId},
{task.Inactive}, 
'{task.LastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

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

        public async Task<bool> DeleteTask(int id, DateTime lastUpdate)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC TaskDelete01 {id}, '{lastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

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

        public async Task<_Task> GetTask(int id)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Tasks WHERE id = {id}";

                var result = connection.Query<_Task>(query).FirstOrDefault();

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

        public async Task<IEnumerable<_Task>> GetAllTasks()
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Tasks";

                var result = connection.Query<_Task>(query).ToList();

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

        public async Task<IEnumerable<_Task>> GetAllTasksWhereBiddingEnded()
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Tasks WHERE [TaskStatusId] = 1 AND [DateBiddingEnd] < '{DateTime.Now.ToString("yyyy-MM-dd")}'";

                var result = connection.Query<_Task>(query).ToList();

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

        public async Task<IEnumerable<_Task>> GetAllUserTasks(int userId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Tasks WHERE [UserId] = {userId}";

                var result = connection.Query<_Task>(query).ToList();

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
