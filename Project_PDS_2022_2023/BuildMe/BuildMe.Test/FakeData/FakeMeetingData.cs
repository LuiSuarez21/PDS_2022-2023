using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    public static class FakeMeetingData
    {
        public static List<Meeting> GetAllMeetings = new List<Meeting>()
        {
                new Meeting { Id = 1, Description = "Name1" },
                new Meeting { Id = 2, Description = "Name2" },
                new Meeting { Id = 3, Description = "Name3" }
        };
    }
}
