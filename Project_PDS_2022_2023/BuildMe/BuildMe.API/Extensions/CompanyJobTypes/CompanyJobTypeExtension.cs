using BuildMe.API.Data.Contracts.CompanyJobType;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.CompanyJobTypes
{
    public static class CompanyJobTypeExtension
    {
        public static CompanyJobType ConvertFromBody(this CreateCompanyJobTypeRequestContract newCompanyJobType)
        {
            return new CompanyJobType()
            {
                CompanyId = newCompanyJobType.CompanyId,
                JobTypeId = newCompanyJobType.JobTypeId,
                AveragePrice = newCompanyJobType.AveragePrice
            };
        }

        public static CompanyJobType ConvertFromBody(this UpdateCompanyJobTypeRequestContract updateCompanyJobType)
        {
            return new CompanyJobType()
            {
                CompanyId = updateCompanyJobType.CompanyId,
                JobTypeId = updateCompanyJobType.JobTypeId,
                AveragePrice = updateCompanyJobType.AveragePrice
            };
        }
    }
}
