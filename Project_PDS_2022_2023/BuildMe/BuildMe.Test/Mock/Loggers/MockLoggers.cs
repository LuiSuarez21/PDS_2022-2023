using BuildMe.API.Controllers;
using BuildMe.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace BuildMe.Test.Mock.Loggers
{
    public class MockUserControllerLogger : Mock<ILogger<UserController>>
    {
    }
    public class MockCityServiceLogger : Mock<ILogger<CityService>>
    {
    }
    public class MockUserServiceLogger : Mock<ILogger<UserService>>
    {
    }
    public class MockCompanyServiceLogger : Mock<ILogger<CompanyService>>
    {
    }
    public class MockCompanyJobTypeServiceLogger : Mock<ILogger<CompanyJobTypeService>>
    {
    }
    public class MockTaskServiceLogger : Mock<ILogger<TaskService>>
    {
    }
    public class MockJobTypeServiceLogger : Mock<ILogger<JobTypeService>>
    {
    }
    public class MockMeetingServiceLogger : Mock<ILogger<MeetingService>>
    {
    }
    public class MockCountryServiceLogger : Mock<ILogger<CountryService>>
    {
    }
    public class MockMeetingStatusServiceLogger : Mock<ILogger<MeetingStatusService>>
    {
    }
    public class MockTaskStatusServiceLogger : Mock<ILogger<TaskStatusService>>
    {
    }
    public class MockUserTypeServiceLogger : Mock<ILogger<UserTypeService>>
    {
    }
}

