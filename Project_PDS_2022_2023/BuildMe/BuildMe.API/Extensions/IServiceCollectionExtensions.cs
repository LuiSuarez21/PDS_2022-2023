using BuildMe.Application.Services.Interfaces;
using BuildMe.Infrastructure.Gateways;
using BuildMe.Infrastructure.Gateways.Interfaces;
using BuildMe.Infrastructure.Services;

namespace BuildMe.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<TaskBiddingService>();
            serviceCollection.AddHostedService<CompanyResetJobsService>();

            serviceCollection.AddSingleton<IUserGateway, UserGateway>();
            serviceCollection.AddSingleton<IUserService, UserService>();
            serviceCollection.AddSingleton<ICityGateway, CityGateway>();
            serviceCollection.AddSingleton<ICityService, CityService>();
            serviceCollection.AddSingleton<ICompanyBudgetGateway, CompanyBudgetGateway>();
            serviceCollection.AddSingleton<ICompanyBudgetService, CompanyBudgetService>();
            serviceCollection.AddSingleton<ICompanyCityGateway, CompanyCityGateway>();
            serviceCollection.AddSingleton<ICompanyCityService, CompanyCityService>();
            serviceCollection.AddSingleton<ICompanyJobTypeGateway, CompanyJobTypeGateway>();
            serviceCollection.AddSingleton<ICompanyJobTypeService, CompanyJobTypeService>();
            serviceCollection.AddSingleton<ICompanyGateway, CompanyGateway>();
            serviceCollection.AddSingleton<ICompanyService, CompanyService>();
            serviceCollection.AddSingleton<ICountryGateway, CountryGateway>();
            serviceCollection.AddSingleton<ICountryService, CountryService>();
            serviceCollection.AddSingleton<IJobTypeGateway, JobTypeGateway>();
            serviceCollection.AddSingleton<IJobTypeService, JobTypeService>();
            serviceCollection.AddSingleton<IMeetingGateway, MeetingGateway>();
            serviceCollection.AddSingleton<IMeetingService, MeetingService>();
            serviceCollection.AddSingleton<IMeetingStatusGateway, MeetingStatusGateway>();
            serviceCollection.AddSingleton<IMeetingStatusService, MeetingStatusService>();
            serviceCollection.AddSingleton<ITaskGateway, TaskGateway>();
            serviceCollection.AddSingleton<ITaskService, TaskService>();
            serviceCollection.AddSingleton<ITaskSatusGateway, TaskStatusGateway>();
            serviceCollection.AddSingleton<ITaskStatusService, TaskStatusService>();
            serviceCollection.AddSingleton<IUserTypeGateway, UserTypeGateway>();
            serviceCollection.AddSingleton<IUserTypeService, UserTypeService>();
            serviceCollection.AddSingleton<IPasswordService, PasswordService>();
            serviceCollection.AddSingleton<IEmailService, EmailService>();
        }
    }
}
