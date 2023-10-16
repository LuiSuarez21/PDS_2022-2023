using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface IMeetingService
    {
        public Task<bool> CreateMeeting(Meeting meeting);
        public Task<bool> UpdateMeeting(Meeting meeting);
        public Task<bool> DeleteMeeting(int id, DateTime lastUpdate);
        public Task<Meeting> GetMeeting(int id);
        public Task<IEnumerable<Meeting>> GetAllMeetings();
    }
}
