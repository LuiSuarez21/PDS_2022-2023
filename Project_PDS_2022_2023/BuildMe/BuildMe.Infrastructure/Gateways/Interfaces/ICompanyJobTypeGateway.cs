using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface ICompanyJobTypeGateway
    {
        public Task<bool> CreateCompanyJobType(CompanyJobType companyJobType);
        public Task<bool> UpdateCompanyJobType(CompanyJobType companyJobType);
        public Task<bool> DeleteCompanyJobType(int companyId, int jobTypeId);
        public Task<CompanyJobType> GetCompanyJobType(int companyId, int jobTypeId);
        public Task<IEnumerable<CompanyJobType>> GetAllCompanyJobTypes(int companyId);
        public Task<IEnumerable<CompanyJobType>> GetCompanyJobTybeBudget(int jobTypeId);
    } 
}
