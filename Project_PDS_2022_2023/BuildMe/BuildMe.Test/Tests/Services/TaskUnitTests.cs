using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using BuildMe.Test.Mock.Services;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class TaskUnitTests
    {
        [TestMethod]
        public async Task TestGetAllCompanies_ReturnsListOfTasks()
        {
            // Arrange
            var _logger = new MockTaskServiceLogger();
            var _taskGateway = new MockTaskGateway();

            // Setup
            _taskGateway.Setup(gateway => gateway.GetAllTasks()).ReturnsAsync(FakeTaskData.GetAllTasks);
            var _taskService = new TaskService(_logger.Object, _taskGateway.Object);

            var response = await _taskService.GetAllTasks();
            var listTasks = response.ToList();

            // Assert
            Assert.AreEqual(FakeTaskData.GetAllTasks.Count, listTasks.Count);
            for (int i = 0; i < FakeTaskData.GetAllTasks.Count; i++)
            {
                Assert.AreEqual(FakeTaskData.GetAllTasks[i].Id, listTasks[i].Id);
                Assert.AreEqual(FakeTaskData.GetAllTasks[i].Description, listTasks[i].Description);
            }
        }

        [DataTestMethod]
        [DataRow(0, true)]
        [DataRow(1, true)]
        public async Task GetTask_ReturnsTaskWhenExist(int taskId, bool exist)
        {
            // Arrange
            var _logger = new MockTaskServiceLogger();
            var taskGateway = new MockTaskGateway();

            // Setup
            taskGateway.Setup(gateway => gateway.GetTask(taskId)).ReturnsAsync(FakeTaskData.GetAllTasks.FirstOrDefault(task => task.Id == taskId));
            var taskService = new TaskService(_logger.Object, taskGateway.Object);

            var response = await taskService.GetTask(taskId);

            // Assert
            if (exist)
                Assert.IsNotNull(response);
            else
                Assert.IsNull(response);
        }
    }
}
