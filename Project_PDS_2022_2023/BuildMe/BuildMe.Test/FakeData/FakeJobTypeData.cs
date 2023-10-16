using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    public static class FakeJobTypeData
    {
        public static List<JobType> GetAllJobTypes = new List<JobType>()
        {
                new JobType { Id = 1, Description = "string1" },
                new JobType { Id = 2, Description = "string2" },
                new JobType { Id = 3, Description = "string3" }
        };
    }
}
