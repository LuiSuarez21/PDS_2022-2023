using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface ICompanyGateway
    {
        public Task<bool> CreateCompany(Company company);
        public Task<bool> UpdateCompany(Company company);
        public Task<bool> DeleteCompany(int id, DateTime lastUpdate);
        public Task<bool> ResetCompanyJobs();
        public Task<Company> GetCompany(int id);
        public Task<IEnumerable<Company>> GetAllCompanies();
        public Task<Company> GetNumberJobsCompany(string name);
    }
}
