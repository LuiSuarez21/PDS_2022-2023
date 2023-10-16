using BuildMe.API.Data.Contracts.MeetingStatus;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.MeetingStatuses
{
    public static class MeetingStatusExtension
    {
        public static MeetingStatus ConvertFromBody(this CreateMeetingStatusRequestContract newMeetingStatus)
        {
            return new MeetingStatus()
            {
                Description = newMeetingStatus.Description
            };
        }

        public static MeetingStatus ConvertFromBody(this UpdateMeetingStatusRequestContract updateMeetingStatus)
        {
            return new MeetingStatus()
            {
                Id = updateMeetingStatus.Id,
                Description = updateMeetingStatus.Description,
                Inactive = updateMeetingStatus.Inactive,
                LastUpdate = updateMeetingStatus.LastUpdate
            };
        }
    }
}
