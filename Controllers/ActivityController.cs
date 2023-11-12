using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Activity>))]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var events = await _activityRepository.GetActivities();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{activityId}")]
        [ProducesResponseType(200, Type = typeof(Activity))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Activity>> GetActivity(int activityId)
        {
            if (!await _activityRepository.ActivityExists(activityId))
                return NotFound(ModelState);
            var events = await _activityRepository.GetActivity(activityId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }
    }
}
