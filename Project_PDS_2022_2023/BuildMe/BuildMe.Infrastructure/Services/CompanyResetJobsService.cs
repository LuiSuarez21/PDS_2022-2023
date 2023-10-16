using BuildMe.Application.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class CompanyResetJobsService : BackgroundService
    {
        private readonly ILogger<TaskBiddingService> _logger;
        private readonly ICompanyService _companyService;

        public CompanyResetJobsService(ILogger<TaskBiddingService> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested)
            {
                if (DateTime.Now.Day == 1)
                {
                    // chamar servico company para dar reset
                    await _companyService.ResetCompanyJobs();
                }

                // Wait for some time before checking again
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
