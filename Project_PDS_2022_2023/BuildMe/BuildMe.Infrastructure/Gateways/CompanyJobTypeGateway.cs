using BuildMe.Application.Configurations;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace BuildMe.Infrastructure.Gateways
{
    public class CompanyJobTypeGateway : ICompanyJobTypeGateway
    {
        private readonly SQLSettings _sqlSettings;

        public CompanyJobTypeGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<bool> CreateCompanyJobType(CompanyJobType companyJobType)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyJobTypeInsert01 {companyJobType.CompanyId}, {companyJobType.JobTypeId}, '{companyJobType.AveragePrice}'";

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

        public async Task<bool> UpdateCompanyJobType(CompanyJobType companyJobType)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyJobTypeUpdate01 {companyJobType.CompanyId}, {companyJobType.JobTypeId}, '{companyJobType.AveragePrice}'";

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

        public async Task<bool> DeleteCompanyJobType(int companyId, int jobTypeId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanJobTypeDelete01 {companyId}, {jobTypeId}";

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

        public async Task<CompanyJobType> GetCompanyJobType(int companyId, int jobTypeId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyJobTypes WHERE CompanyId = {companyId} AND JobTypeId = {jobTypeId}";

                var result = connection.Query<CompanyJobType>(query).FirstOrDefault();

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

        /*
        public static async Task<CompanyJobType> GetCompanyJobType2(int jobTypeId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyJobTypes WHERE JobTypesId = {jobTypeId}";

                var result = connection.Query<CompanyJobType>(query).FirstOrDefault();

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
        */

        public async Task<IEnumerable<CompanyJobType>> GetCompanyJobTybeBudget(int jobTypeId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyJobTypes WHERE JobTypesId = {jobTypeId}";

                var result = connection.Query<CompanyJobType>(query).AsList();

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

        public async Task<IEnumerable<CompanyJobType>> GetAllCompanyJobTypes(int companyId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyJobTypes WHERE CompanyId = {companyId}";

                var result = connection.Query<CompanyJobType>(query).ToList();

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