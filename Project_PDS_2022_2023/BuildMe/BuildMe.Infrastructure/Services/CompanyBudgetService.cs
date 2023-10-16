using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;

namespace BuildMe.Infrastructure.Services
{
    public class CompanyBudgetService : ICompanyBudgetService
    {
        private readonly ILogger<CompanyBudgetService> _logger;
        private readonly ICompanyBudgetGateway _companyBudgetGateway;

        public CompanyBudgetService(ILogger<CompanyBudgetService> logger, ICompanyBudgetGateway companyBudgetGateway)
        {
            _logger = logger;
            _companyBudgetGateway = companyBudgetGateway;
        }

        public async Task<bool> CreateCompanyBudget(CompanyBudget companyBudget)
        {
            try
            {
                return await _companyBudgetGateway.CreateCompanyBudget(companyBudget);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert company with id {companyBudget.CompanyId} and jobType with id {companyBudget.TaskId}");
                throw;
            }
        }

        public async Task<bool> UpdateCompanyBudget(CompanyBudget companyBudget)
        {
            try
            {
                return await _companyBudgetGateway.UpdateCompanyBudget(companyBudget);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update company with id {companyBudget.CompanyId} and jobType with id {companyBudget.TaskId}");
                throw;
            }
        }

        public async Task<bool> DeleteCompanyBudget(int companyId, int taskId)
        {
            try
            {
                return await _companyBudgetGateway.DeleteCompanyBudget(companyId, taskId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete jobType {taskId} from company {companyId}");
                throw;
            }
        }

        public async Task<CompanyBudget> GetCompanyBudget(int companyId, int taskId)
        {
            try
            {
                return await _companyBudgetGateway.GetCompanyBudget(companyId, taskId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get jobType {taskId} from company {companyId}");
                throw;
            }
        }

        public async Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithCompany(int companyId)
        {
            try
            {
                return await _companyBudgetGateway.GetAllCompanyBudgetsWithCompany(companyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get all CompanyBudgets from company {companyId}");
                throw;
            }
        }

        public async Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithTask(int taskId)
        {
            try
            {
                return await _companyBudgetGateway.GetAllCompanyBudgetsWithTask(taskId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get all CompanyBudgets from company {taskId}");
                throw;
            }
        }
    }
}