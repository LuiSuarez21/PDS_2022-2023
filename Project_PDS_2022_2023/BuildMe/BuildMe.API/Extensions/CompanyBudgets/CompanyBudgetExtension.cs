using BuildMe.API.Data.Contracts.CompanyBudget;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.CompanyBudgets
{
    public static class CompanyBudgetExtension
    {
        public static CompanyBudget ConvertFromBody(this CreateCompanyBudgetRequestContract newCompanyBudget)
        {
            return new CompanyBudget()
            {
                CompanyId = newCompanyBudget.CompanyId,
                TaskId = newCompanyBudget.TaskId,
                Value = newCompanyBudget.Value
            };
        }

        public static CompanyBudget ConvertFromBody(this UpdateCompanyBudgetRequestContract updateCompanyBudget)
        {
            return new CompanyBudget()
            {
                CompanyId = updateCompanyBudget.CompanyId,
                TaskId = updateCompanyBudget.TaskId,
                Value = updateCompanyBudget.Value
            };
        }
    }
}
