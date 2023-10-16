using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface ICompanyBudgetGateway
    {
        public Task<bool> CreateCompanyBudget(CompanyBudget companyBudget);
        public Task<bool> UpdateCompanyBudget(CompanyBudget companyBudget);
        public Task<bool> DeleteCompanyBudget(int companyId, int taskId);
        public Task<CompanyBudget> GetCompanyBudget(int companyId, int taskId);
        public Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithCompany(int companyId);
        public Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithTask(int taskId);
    }
}
