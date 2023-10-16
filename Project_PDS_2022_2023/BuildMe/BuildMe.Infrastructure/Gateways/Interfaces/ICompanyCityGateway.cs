using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface ICompanyCityGateway
    {
        public Task<bool> UpdateCompanyCity(CompanyCity companyCity);
        public Task<bool> CreateCompanyCity(CompanyCity companyCity);
        public Task<bool> DeleteCompanyCity(int companyId, int cityId);
        public Task<CompanyCity> GetCompanyCity(int companyId, int cityId);
        public Task<IEnumerable<CompanyCity>> GetAllCompanyCities(int companyId);
    }
}
