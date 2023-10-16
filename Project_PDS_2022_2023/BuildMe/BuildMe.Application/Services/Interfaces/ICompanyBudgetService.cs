using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface ICompanyBudgetService
    {
        public Task<bool> CreateCompanyBudget(CompanyBudget companyBudget);
        public Task<bool> UpdateCompanyBudget(CompanyBudget companyBudget);
        public Task<bool> DeleteCompanyBudget(int companyId, int taskId);
        public Task<CompanyBudget> GetCompanyBudget(int companyId, int taskId);
        public Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithCompany(int companyId);
        public Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithTask(int taskId);
    }
}
