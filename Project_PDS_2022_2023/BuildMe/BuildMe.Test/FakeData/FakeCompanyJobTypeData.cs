using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    public static class FakeCompanyJobTypeData
    {
        public static List<CompanyJobType> GetCompaniesJobTypes = new List<CompanyJobType>()
        {
                new CompanyJobType { JobTypeId = 2, CompanyId = 1, AveragePrice = 30  },
                new CompanyJobType { JobTypeId = 2, CompanyId = 2, AveragePrice = 35  },
                new CompanyJobType { JobTypeId = 2, CompanyId = 3, AveragePrice = 50  }
        };
    }
}