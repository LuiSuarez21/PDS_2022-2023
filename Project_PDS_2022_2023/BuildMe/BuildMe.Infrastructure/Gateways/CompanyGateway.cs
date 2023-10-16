using BuildMe.Application.Configurations;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BuildMe.Infrastructure.Gateways
{
    public class CompanyGateway : ICompanyGateway
    {
        private readonly SQLSettings _sqlSettings;

        public CompanyGateway(IApplicationSettings applicationSettings)
        {
            _sqlSettings = applicationSettings.SQLSettings;
        }

        public async Task<bool> CreateCompany(Company company)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = @$"EXEC CompanyInsert01 '{company.Name}', '{company.Address}', '{company.VAT}', {company.NumberMonthlyJobs}, {company.CountryId}";

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

        public async Task<bool> UpdateCompany(Company company)
        {
            await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
            await connection.OpenAsync();

            var query = @$"EXEC CompanyUpdate01 {company.Id}, '{company.Name}', '{company.Address}', '{company.VAT}', {company.NumberMonthlyJobs}, {company.CountryId}, {company.Inactive}, '{company.LastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

            var result = connection.Query<int>(query).FirstOrDefault();

            if (result == 1)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteCompany(int id, DateTime lastUpdate)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $@"EXEC CityDelete01 {id}, '{lastUpdate:yyyy-MM-dd HH:mm:ss.fff}'";

                /* NOTA!!!!
                 * Nao podemos remover, devemos ter um active e ao eliminar, metemos o active a 0 e o nome da empresa fica
                 * com o ForgottenCompany_id
                 * */

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

        public async Task<Company> GetCompany(int id)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Companies WHERE id = {id}";

                var result = connection.Query<Company>(query).FirstOrDefault();

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

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Companies";

                var result = connection.Query<Company>(query).ToList();

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

        public async Task<Company> GetNumberJobsCompany(string name)
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"SELECT * FROM Companies WHERE 'Name' = {name}";

                var result = connection.Query<Company>(query).FirstOrDefault();

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

        public async Task<bool> ResetCompanyJobs()
        {
            try
            {
                await using var connection = new SqlConnection(_sqlSettings.ConnectionString);
                await connection.OpenAsync();

                var query = $"UPDATE Companies SET [NumberOfJobs] = 0";

                var result = connection.Query<int>(query).FirstOrDefault();

                if (result != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
