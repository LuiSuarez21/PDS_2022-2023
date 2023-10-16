using BuildMe.Application.Configurations;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BuildMe.Infrastructure.Gateways
{
    public class MeetingStatusGateway : IMeetingStatusGateway
    {
        private readonly SQLSettings _sqlSettings;

        public MeetingStatusGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<bool> CreateMeetingStatus(MeetingStatus meetingStatus)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC MeetingStatusInsert01 '{meetingStatus.Description}'";

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

        public async Task<bool> UpdateMeetingStatus(MeetingStatus meetingStatus)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC MeetingStatusUpdate01 {meetingStatus.Id}, '{meetingStatus.Description}', {meetingStatus.Inactive}, '{meetingStatus.LastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

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

        public async Task<bool> DeleteMeetingStatus(int id, DateTime lastUpdate)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $@"EXEC MeetingStatusDelete01 {id}, '{lastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

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

        public async Task<MeetingStatus> GetMeetingStatus(int id)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM MeetingStatuses WHERE id = {id}";

                var result = connection.Query<MeetingStatus>(query).FirstOrDefault();

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

        public async Task<IEnumerable<MeetingStatus>> GetAllMeetingStatuses()
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM MeetingStatuses";

                var result = connection.Query<MeetingStatus>(query).ToList();

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