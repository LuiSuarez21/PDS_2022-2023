using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    public static class FakeCompanyData
    {
        public static List<Company> GetAllCompanies = new List<Company>()
        {
                new Company { Id = 1, Name = "Name1" },
                new Company { Id = 2, Name = "Name2" },
                new Company { Id = 3, Name = "Name3" }
        };
    }
}
