using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<Company> GetCompany(int id);
        public Task<bool> CreateCompany(Company company);
        public Task<bool> UpdateCompany(Company company);
        public Task<bool> DeleteCompany(int id, DateTime lastUpdate);
        public Task<int> GetAllJobsFromCompany(string name);
        public Task<bool> ResetCompanyJobs();
        public Task<IEnumerable<Company>> GetAllCompanies();
        public Task<Company> GetCompanyWithMostJobs();
    }
}
