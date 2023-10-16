using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ILogger<TaskService> _logger;
        private readonly ITaskGateway _taskGateway;

        public TaskService(ILogger<TaskService> logger, ITaskGateway taskGateway)
        {
            _logger = logger;
            _taskGateway = taskGateway;
        }

        public async Task<bool> CreateTask(_Task task)
        {
            try
            {
                return await _taskGateway.CreateTask(task);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateTask(_Task task)
        {
            try
            {
                return await _taskGateway.UpdateTask(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to update task with id [{id}]", task.Id);
                throw;
            }
        }

        public async Task<bool> DeleteTask(int id, DateTime lastUpdate)
        {
            try
            {
                return await _taskGateway.DeleteTask(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to delete task with id [{id}]", id);
                throw;
            }
        }

        public async Task<_Task> GetTask(int id)
        {
            try
            {
                var task = await _taskGateway.GetTask(id);
                return task;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get task with id [{id}]", id);
                throw;
            }
        }

        public async Task<IEnumerable<_Task>> GetAllTasks()
        {
            try
            {
                var tasks = await _taskGateway.GetAllTasks();
                return tasks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all companies list");
                throw;
            }
        }

        public async Task<List<_Task>> GetAllTasksWhereBiddingEnded()
        {
            try
            {
                var tasks = await _taskGateway.GetAllTasksWhereBiddingEnded();
                return tasks.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all tasks where bidding ended");
                throw;
            }
        }

        public async Task<List<_Task>> GetAllUserTasks(int userId)
        {
            try
            {
                var tasks = await _taskGateway.GetAllUserTasks(userId);
                return tasks.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all user tasks list");
                throw;
            }
        }
    }
}
