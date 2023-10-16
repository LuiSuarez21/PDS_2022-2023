using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface IMeetingGateway
    {
        public Task<bool> CreateMeeting(Meeting meetings);
        public Task<bool> UpdateMeeting(Meeting meetings);
        public Task<bool> DeleteMeeting(int id, DateTime lastUpdate);
        public Task<Meeting> GetMeeting(int id);
        public Task<IEnumerable<Meeting>> GetAllMeetings();
    }
}
