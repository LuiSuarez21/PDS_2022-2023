using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface IMeetingStatusService
    {
        public Task<bool> CreateMeetingStatus(MeetingStatus meetingStatus);
        public Task<bool> UpdateMeetingStatus(MeetingStatus meetingStatus);
        public Task<bool> DeleteMeetingStatus(int id, DateTime lastUpdate);
        public Task<MeetingStatus> GetMeetingStatus(int id);
        public Task<IEnumerable<MeetingStatus>> GetAllMeetingStatuses();
    }
}
