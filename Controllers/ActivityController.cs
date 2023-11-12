using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using GoTravnikApi.Repository;
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

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Activity))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            if (!await _activityRepository.ActivityExists(id))
                return NotFound(ModelState);
            var events = await _activityRepository.GetActivity(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<Activity>))]
        public async Task<ActionResult<List<Activity>>> GetActivities(string name)
        {
            var activities = await _activityRepository.GetActivities(name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(activities);
        }
    }
}
