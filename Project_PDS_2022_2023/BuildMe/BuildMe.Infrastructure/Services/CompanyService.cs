using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> _logger;
        private readonly ICompanyGateway _companyGateway;

        public CompanyService(ILogger<CompanyService> logger, ICompanyGateway companyGateway)
        {
            _logger = logger;
            _companyGateway = companyGateway;
        }

        public async Task<bool> CreateCompany(Company company)
        {
            try
            {
                return await _companyGateway.CreateCompany(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to insert company with id [{id}]", company.Id);
                throw;
            }
        }

        public async Task<bool> UpdateCompany(Company company)
        {
            try
            {
                return await _companyGateway.UpdateCompany(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to update company with id [{id}]", company.Id);
                throw;
            }
        }

        public async Task<bool> DeleteCompany(int id, DateTime lastUpdate)
        {
            try
            {
                return await _companyGateway.DeleteCompany(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to delete company with id [{id}]", id);
                throw;
            }
        }

        public async Task<Company> GetCompany(int id)
        {
            try
            {
                var company = await _companyGateway.GetCompany(id);
                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get company with id [{id}]", id);
                throw;
            }
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                var companies = await _companyGateway.GetAllCompanies();
                return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all companies list");
                throw;
            }
        }

        public async Task<bool> ResetCompanyJobs()
        {
            try
            {
                return await _companyGateway.ResetCompanyJobs();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to reset company jobs");
                throw;
            }
        }

        public async Task<int> GetAllJobsFromCompany(string name)
        {
            try
            {
                var result = await _companyGateway.GetNumberJobsCompany(name);
                return result.NumberMonthlyJobs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get all jobs done by a company with the Name = '{name}'");
                throw;
            }
        }

        public async Task<Company> GetCompanyWithMostJobs()
        {
            try
            {
                Company cAux = new Company(); 
                int maior = 0;
                var companies = await _companyGateway.GetAllCompanies();
                foreach(var c in companies)
                {
                    if (c.NumberMonthlyJobs == 0 && maior == 0) cAux = c;
                    if (c.NumberMonthlyJobs > maior)
                    {
                        maior = c.NumberMonthlyJobs;
                        cAux = c;
                    }
                }
                return cAux;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get all jobs done");
                throw;
            }
        }
    }
}
