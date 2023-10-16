using BuildMe.Domain.Model;


namespace BuildMe.Test.FakeData
{
    public static class FakeTaskStatusData
    {
        public static List<_TaskStatus> GetAllTaskStatuses = new List<_TaskStatus>()
        {
                new _TaskStatus { Id = 1, Description = "Name1" },
                new _TaskStatus { Id = 2, Description = "Name2" },
                new _TaskStatus { Id = 3, Description = "Name3" }
        };
    }
}
