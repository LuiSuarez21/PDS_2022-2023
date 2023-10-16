using BuildMe.Application.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class TaskBiddingService : BackgroundService
    {
        private readonly ILogger<TaskBiddingService> _logger;
        private readonly ITaskService _taskService;
        private readonly ICompanyBudgetService _companyBudgetService;
        private readonly ICompanyService _companyService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public TaskBiddingService(ILogger<TaskBiddingService> logger,
            ITaskService taskService,
            ICompanyBudgetService companyBudgetService,
            ICompanyService companyService,
            IEmailService emailService,
            IUserService userService)
        {
            _logger = logger;
            _taskService = taskService;
            _companyBudgetService = companyBudgetService;
            _companyService = companyService;
            _emailService = emailService;
            _userService = userService;
        }

        /// <summary>
        /// Este metodo é um metodo que precisa de fazer umas quantas ações:
        ///     1º - precisa de ir buscar todas as Tasks em que o TaskStatus seja igual a 1 e a DateBiddingEnd seja inferior ao tempo atual
        ///     2º - enviar um email ao utilizador com a empresa mais barata selecionada e que o IsRejected esteja a 0
        ///     3º - fazer update a todas as Tasks para o proximo status (TaskStatus numero 2)
        /// </summary>
        /// <param name="stoppingToken">token the paragem</param>
        /// <returns>nao necessita de retornar nada</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string body;

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // ir buscar todas as tasks
                    var tasks = await _taskService.GetAllTasksWhereBiddingEnded();

                    foreach (var task in tasks)
                    {
                        body = "";

                        // 1º
                        var budgets = await _companyBudgetService.GetAllCompanyBudgetsWithTask(task.Id);

                        if (budgets.Count() == 0)
                        {
                            body += "No company budgeted on the service. This service will not be provided at this time. Please change bidding time.";
                        }
                        else
                        {
                            var minCompany = budgets.Where(b => !b.IsRejected).OrderBy(b => b.Value).First();
                            var company = await _companyService.GetCompany(minCompany.CompanyId);

                            body += $"Hello,<br>Company selected {company.Name} with a budget of €{minCompany.Value}";
                        }

                        // 2º
                        var user = await _userService.GetUser(task.UserId);
                        string subject = $"Task {task.Id} ready";
                        await _emailService.SendEmailAsync(user.Email, subject, body);

                        // 3º 
                        task.TaskStatusId = 2;
                        var result = await _taskService.UpdateTask(task);

                        if (!result)
                            throw new Exception("Task could not be updated.");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    // Wait for some time before checking again
                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                }
            }
        }
    }
}
