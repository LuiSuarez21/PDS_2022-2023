using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    public static class FakeCountryData
    {
        public static List<Country> GetAllCountries = new List<Country>()
        {
                new Country { Id = 1, Description = "Name1" },
                new Country { Id = 2, Description = "Name2" },
                new Country { Id = 3, Description = "Name3" }
        };
    }
}
