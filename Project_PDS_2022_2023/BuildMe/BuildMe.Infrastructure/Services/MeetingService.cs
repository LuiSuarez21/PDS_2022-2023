using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMeetingGateway _meetingGateway;

        public MeetingService(ILogger<UserService> logger, IMeetingGateway meetingGateway)
        {
            _logger = logger;
            _meetingGateway = meetingGateway;
        }

        public async Task<bool> CreateMeeting(Meeting meeting)
        {
            try
            {
                return await _meetingGateway.CreateMeeting(meeting);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert meeting with id [{meeting.Id}]");
                throw;
            }
        }

        public async Task<bool> UpdateMeeting(Meeting meeting)
        {
            try
            {
                return await _meetingGateway.UpdateMeeting(meeting);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update meeting with id [{meeting.Id}]");
                throw;
            }
        }

        public async Task<bool> DeleteMeeting(int id, DateTime lastUpdate)
        {
            try
            {
                return await _meetingGateway.DeleteMeeting(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete meeting with id [{id}]");
                throw;
            }
        }

        public async Task<Meeting> GetMeeting(int id)
        {
            try
            {
                return await _meetingGateway.GetMeeting(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get meeting with id [{id}]");
                throw;
            }
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetings()
        {
            try
            {
                var cities = await _meetingGateway.GetAllMeetings();
                return cities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all cities list");
                throw;
            }
        }
    }
}