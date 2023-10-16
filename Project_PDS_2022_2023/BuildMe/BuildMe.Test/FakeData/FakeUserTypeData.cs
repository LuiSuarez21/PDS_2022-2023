using BuildMe.Domain.Model;


namespace BuildMe.Test.FakeData
{
    public static class FakeUserTypeData
    {
        public static List<UserType> GetAllUserTypes = new List<UserType>()
        {
                new UserType { Id = 1, Description = "Name1" },
                new UserType { Id = 2, Description = "Name2" },
                new UserType { Id = 3, Description = "Name3" }
        };
    }
}
