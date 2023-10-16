using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class MeetingStatusService : IMeetingStatusService
    {
        private readonly ILogger<MeetingStatusService> _logger;
        private readonly IMeetingStatusGateway _meetingStatusGateway;

        public MeetingStatusService(ILogger<MeetingStatusService> logger, IMeetingStatusGateway meetingStatusGateway)
        {
            _logger = logger;
            _meetingStatusGateway = meetingStatusGateway;
        }

        public async Task<bool> CreateMeetingStatus(MeetingStatus meetingStatus)
        {
            try
            {
                return await _meetingStatusGateway.CreateMeetingStatus(meetingStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert meetingStatus with id [{meetingStatus.Id}]");
                throw;
            }
        }

        public async Task<bool> UpdateMeetingStatus(MeetingStatus meetingStatus)
        {
            try
            {
                return await _meetingStatusGateway.UpdateMeetingStatus(meetingStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update meetingStatus with id [{meetingStatus.Id}]");
                throw;
            }
        }

        public async Task<bool> DeleteMeetingStatus(int id, DateTime lastUpdate)
        {
            try
            {
                return await _meetingStatusGateway.DeleteMeetingStatus(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete meetingStatus with id [{id}]");
                throw;
            }
        }

        public async Task<MeetingStatus> GetMeetingStatus(int id)
        {
            try
            {
                return await _meetingStatusGateway.GetMeetingStatus(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get meetingStatus with id [{id}]");
                throw;
            }
        }

        public async Task<IEnumerable<MeetingStatus>> GetAllMeetingStatuses()
        {
            try
            {
                var cities = await _meetingStatusGateway.GetAllMeetingStatuses();
                return cities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all meetingStatuses list");
                throw;
            }
        }
    }
}