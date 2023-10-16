using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class TaskStatusService : ITaskStatusService
    {
        private readonly ILogger<TaskStatusService> _logger;
        private readonly ITaskSatusGateway _taskSatusGateway;

        public TaskStatusService(ILogger<TaskStatusService> logger, ITaskSatusGateway taskSatusGateway)
        {
            _logger = logger;
            _taskSatusGateway = taskSatusGateway;
        }

        public async Task<bool> CreateTaskStatus(_TaskStatus taskStatus)
        {
            try
            {
                return await _taskSatusGateway.CreateTaskStatus(taskStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert taskStatus with id [{taskStatus.Id}]");
                throw;
            }
        }

        public async Task<bool> UpdateTaskStatus(_TaskStatus taskStatus)
        {
            try
            {
                return await _taskSatusGateway.UpdateTaskStatus(taskStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update taskStatus with id [{taskStatus.Id}]");
                throw;
            }
        }

        public async Task<bool> DeleteTaskStatus(int id, DateTime lastUpdate)
        {
            try
            {
                return await _taskSatusGateway.DeleteTaskStatus(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete taskStatus with id [{id}]");
                throw;
            }
        }

        public async Task<_TaskStatus> GetTaskStatus(int id)
        {
            try
            {
                return await _taskSatusGateway.GetTaskStatus(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get taskStatus with id [{id}]");
                throw;
            }
        }

        public async Task<IEnumerable<_TaskStatus>> GetAllTaskStatuses()
        {
            try
            {
                var taskStatuses = await _taskSatusGateway.GetAllTaskStatuses();
                return taskStatuses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all taskStatuses list");
                throw;
            }
        }
    }
}