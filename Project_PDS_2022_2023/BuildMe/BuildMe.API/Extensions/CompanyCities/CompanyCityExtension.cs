using BuildMe.API.Data.Contracts.CompanyCity;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.CompanyCities
{
    public static class CompanyCityExtension
    {
        public static CompanyCity ConvertFromBody(this CreateCompanyCityRequestContract newCompanyCity)
        {
            return new CompanyCity()
            {
                CompanyId = newCompanyCity.CompanyId,
                CityId = newCompanyCity.CityId
            };
        }

        public static CompanyCity ConvertFromBody(this UpdateCompanyCityRequestContract updateCompanyCity)
        {
            return new CompanyCity()
            {
                CompanyId = updateCompanyCity.CompanyId,
                CityId = updateCompanyCity.CityId
            };
        }
    }
}
