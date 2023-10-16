using BuildMe.Application.Configurations;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BuildMe.Infrastructure.Gateways
{
    public class CompanyCityGateway : ICompanyCityGateway
    {
        private readonly SQLSettings _sqlSettings;

        public CompanyCityGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<bool> CreateCompanyCity(CompanyCity companyCity)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyCityInsert01 {companyCity.CompanyId}, {companyCity.CityId}";

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

        public async Task<bool> UpdateCompanyCity(CompanyCity companyCity)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyCityUpdate01 {companyCity.CompanyId}, {companyCity.CityId}";

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

        public async Task<bool> DeleteCompanyCity(int companyId, int cityId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyCityDelete01 {companyId}, {cityId}";

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

        public async Task<CompanyCity> GetCompanyCity(int companyId, int cityId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyCities WHERE CompanyId = {companyId} AND CityId = {cityId}";

                var result = connection.Query<CompanyCity>(query).FirstOrDefault();

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

        public async Task<IEnumerable<CompanyCity>> GetAllCompanyCities(int companyId)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM CompanyCities WHERE CompanyId = {companyId}";

                var result = connection.Query<CompanyCity>(query).ToList();

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