using BuildMe.API.Data.Contracts.Meeting;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.Meetings
{
    public static class MeetingExtension
    {
        public static Meeting ConvertFromBody(this CreateMeetingRequestContract newMeeting)
        {
            return new Meeting()
            {
                Description = newMeeting.Description,
                Date = newMeeting.Date,
                Notes = newMeeting.Notes,
                UserId = newMeeting.UserId,
                CompanyId = newMeeting.CompanyId,
                MeetingStatusId = newMeeting.MeetingStatusId
            };
        }

        public static Meeting ConvertFromBody(this UpdateMeetingRequestContract updateMeeting)
        {
            return new Meeting()
            {
                Id = updateMeeting.Id,
                Description = updateMeeting.Description,
                Date = updateMeeting.Date,
                Notes = updateMeeting.Notes,
                UserId = updateMeeting.UserId,
                CompanyId = updateMeeting.CompanyId,
                MeetingStatusId = updateMeeting.MeetingStatusId,
                Inactive = updateMeeting.Inactive,
                LastUpdate = updateMeeting.LastUpdate
            };
        }
    }
}
