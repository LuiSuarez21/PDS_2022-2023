using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface ICompanyCityService
    {
        public Task<bool> CreateCompanyCity(CompanyCity companyCity);
        public Task<bool> UpdateCompanyCity(CompanyCity companyCity);
        public Task<bool> DeleteCompanyCity(int companyId, int cityId);
        public Task<CompanyCity> GetCompanyCity(int companyId, int cityId);
        public Task<IEnumerable<CompanyCity>> GetAllCompanyCities(int companyId);
    }
}
