using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    public static class FakeCityData
    {
        public static List<City> GetAllCities = new List<City>()
        {
                new City { Id = 1, Description = "Name1" },
                new City { Id = 2, Description = "Name2" },
                new City { Id = 3, Description = "Name3" }
        };
    }
}
