using BuildMe.API.Data.Contracts.Meeting;
using BuildMe.API.Extensions.Meetings;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class MeetingController : ApiBaseController
    {
        private readonly ILogger<MeetingController> _logger;
        private readonly IMeetingService _meetingService;

        public MeetingController(ILogger<MeetingController> logger, IMeetingService meetingService)
        {
            _logger = logger;
            _meetingService = meetingService;
        }

        [Authorize(Roles = "NormalUser")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingRequestContract body)
        {
            try
            {
                var meeting = body.ConvertFromBody();
                var response = await _meetingService.CreateMeeting(meeting);

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
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateMeeting([FromBody] UpdateMeetingRequestContract body)
        {
            try
            {
                var meeting = body.ConvertFromBody();
                var response = await _meetingService.UpdateMeeting(meeting);

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
        [HttpDelete]
        [Route("delete/{id}/{lastUpdate}")]
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "id")] int id, [FromRoute(Name = "lastUpdate")] DateTime lastUpdate)
        {
            try
            {
                var response = await _meetingService.DeleteMeeting(id, lastUpdate);

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
        public async Task<IActionResult> GetMeeting([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null.");

                var userType = await _meetingService.GetMeeting(id);

                if (userType == null)
                    throw new Exception("Meeting cannot be null (Meeting not found).");

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
        public async Task<IActionResult> GetAllMeetings()
        {
            try
            {
                var cities = await _meetingService.GetAllMeetings();

                if (cities == null)
                    throw new Exception("Error when trying to get all meetings.");

                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
