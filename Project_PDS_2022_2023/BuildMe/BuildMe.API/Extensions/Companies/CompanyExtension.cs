using BuildMe.API.Data.Contracts.Company;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.Companies
{
    public static class CompanyExtension
    {
        public static Company ConvertFromBody(this CreateCompanyRequestContract newCompany)
        {
            return new Company()
            {
                Name = newCompany.Name,
                Address = newCompany.Address,
                VAT = newCompany.VAT,
                NumberMonthlyJobs = newCompany.NumberMonthlyJobs,
                CountryId = newCompany.CountryId
            };
        }

        public static Company ConvertFromBody(this UpdateCompanyRequestContract updateCompany)
        {
            return new Company()
            {
                Id = updateCompany.Id,
                Name = updateCompany.Name,
                Address = updateCompany.Address,
                VAT = updateCompany.VAT,
                NumberMonthlyJobs = updateCompany.NumberMonthlyJobs,
                CountryId = updateCompany.CountryId,
                Inactive = updateCompany.Inactive,
                LastUpdate = updateCompany.LastUpdate
            };
        }
    }
}