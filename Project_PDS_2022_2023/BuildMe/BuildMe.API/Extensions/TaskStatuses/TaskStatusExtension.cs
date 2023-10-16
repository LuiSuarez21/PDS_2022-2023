using BuildMe.API.Data.Contracts.TaskStatus;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.TaskStatuses
{
    public static class TaskStatusExtension
    {
        public static _TaskStatus ConvertFromBody(this CreateTaskStatusRequestContract newTaskStatus)
        {
            return new _TaskStatus()
            {
                Description = newTaskStatus.Description
            };
        }

        public static _TaskStatus ConvertFromBody(this UpdateTaskStatusRequestContract updateTaskStatus)
        {
            return new _TaskStatus()
            {
                Id = updateTaskStatus.Id,
                Description = updateTaskStatus.Description,
                Inactive = updateTaskStatus.Inactive,
                LastUpdate = updateTaskStatus.LastUpdate
            };
        }
    }
}
