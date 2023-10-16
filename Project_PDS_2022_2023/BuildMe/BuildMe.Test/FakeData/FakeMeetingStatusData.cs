using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    public static class FakeMeetingStatusData
    {
        public static List<MeetingStatus> GetAllMeetingStatuses = new List<MeetingStatus>()
        {
                new MeetingStatus { Id = 1, Description = "Name1" },
                new MeetingStatus { Id = 2, Description = "Name2" },
                new MeetingStatus { Id = 3, Description = "Name3" }
        };
    }
}
