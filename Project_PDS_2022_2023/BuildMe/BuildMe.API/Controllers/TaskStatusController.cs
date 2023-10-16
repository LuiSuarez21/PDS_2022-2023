using BuildMe.API.Data.Contracts.TaskStatus;
using BuildMe.API.Extensions.TaskStatuses;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class TaskStatusController : ApiBaseController
    {
        private readonly ILogger<TaskStatusController> _logger;
        private readonly ITaskStatusService _taskStatusService;

        public TaskStatusController(ILogger<TaskStatusController> logger, ITaskStatusService taskStatusService)
        {
            _logger = logger;
            _taskStatusService = taskStatusService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateTaskStatus([FromBody] CreateTaskStatusRequestContract body)
        {
            try
            {
                var taskStatus = body.ConvertFromBody();
                var response = await _taskStatusService.CreateTaskStatus(taskStatus);

                if (!response)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTaskStatus([FromBody] UpdateTaskStatusRequestContract body)
        {
            try
            {
                var taskStatus = body.ConvertFromBody();
                var response = await _taskStatusService.UpdateTaskStatus(taskStatus);

                if (!response)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("delete/{id}/{lastUpdate}")]
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "id")] int id, [FromRoute(Name = "lastUpdate")] DateTime lastUpdate)
        {
            try
            {
                var response = await _taskStatusService.DeleteTaskStatus(id, lastUpdate);

                if (!response)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTaskStatus([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null.");

                var userType = await _taskStatusService.GetTaskStatus(id);

                if (userType == null)
                    throw new Exception("TaskStatus cannot be null (TaskStatus not found).");

                return Ok(userType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllTaskStatuses()
        {
            try
            {
                var taskStatuses = await _taskStatusService.GetAllTaskStatuses();

                if (taskStatuses == null)
                    throw new Exception("Error when trying to get all taskStatuses.");

                return Ok(taskStatuses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
