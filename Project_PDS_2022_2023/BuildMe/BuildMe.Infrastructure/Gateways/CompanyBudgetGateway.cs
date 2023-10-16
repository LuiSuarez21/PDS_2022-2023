using BuildMe.Application.Configurations;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BuildMe.Infrastructure.Gateways
{
    public class CompanyBudgetGateway : ICompanyBudgetGateway
    {
        private readonly SQLSettings _sqlSettings;

        public CompanyBudgetGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<bool> CreateCompanyBudget(CompanyBudget companyBudget)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyBudgetInsert01 {companyBudget.CompanyId}, {companyBudget.TaskId}, {companyBudget.Value}";

                var result = connection.Query<int>(query).FirstOrDefault();

                if (result != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCompanyBudget(CompanyBudget companyBudget)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyBudgetUpdate01 {companyBudget.CompanyId}, {companyBudget.TaskId}, '{companyBudget.Value}', {companyBudget.IsRejected}";

                var result = connection.Query<int>(query).FirstOrDefault();

                if (result == 1)
                    return true;
                else 
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCompanyBudget(int companyId, int taskId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyBudgetDelete01 {companyId}, {taskId}";

                var result = connection.Query<int>(query).FirstOrDefault();

                if (result == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CompanyBudget> GetCompanyBudget(int companyId, int taskId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyBudgets WHERE CompanyId = {companyId} AND TaskId = {taskId}";

                var result = connection.Query<CompanyBudget>(query).FirstOrDefault();

                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithCompany(int companyId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyBudgets WHERE CompanyId = {companyId}";

                var result = connection.Query<CompanyBudget>(query).ToList();

                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompanyBudget>> GetAllCompanyBudgetsWithTask(int taskId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyBudgets WHERE TaskId = {taskId}";

                var result = connection.Query<CompanyBudget>(query).ToList();

                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}