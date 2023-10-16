using BuildMe.API.Data.Contracts.MeetingStatus;
using BuildMe.API.Extensions.MeetingStatuses;
using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class MeetingStatusController : ApiBaseController
    {
        private readonly ILogger<MeetingStatusController> _logger;
        private readonly IMeetingStatusService _meetingStatusService;

        public MeetingStatusController(ILogger<MeetingStatusController> logger, IMeetingStatusService meetingStatusService)
        {
            _logger = logger;
            _meetingStatusService = meetingStatusService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCity([FromBody] CreateMeetingStatusRequestContract body)
        {
            try
            {
                var meetingStatus = body.ConvertFromBody();
                var response = await _meetingStatusService.CreateMeetingStatus(meetingStatus);

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
        public async Task<IActionResult> UpdateMeetingStatus([FromBody] UpdateMeetingStatusRequestContract body)
        {
            try
            {
                var meetingStatus = body.ConvertFromBody();
                var response = await _meetingStatusService.UpdateMeetingStatus(meetingStatus);

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
                var response = await _meetingStatusService.DeleteMeetingStatus(id, lastUpdate);

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
        public async Task<IActionResult> GetMeetingStatus([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null.");

                var userType = await _meetingStatusService.GetMeetingStatus(id);

                if (userType == null)
                    throw new Exception("MeetingStatus cannot be null (MeetingStatus not found).");

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
        public async Task<IActionResult> GetAllMeetingStatuses()
        {
            try
            {
                var meetingStatuses = await _meetingStatusService.GetAllMeetingStatuses();

                if (meetingStatuses == null)
                    throw new Exception("Error when trying to get all meetingStatuses.");

                return Ok(meetingStatuses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
