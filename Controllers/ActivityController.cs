using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
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
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public ActivityController(IActivityRepository activityRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
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

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddActivity([FromBody] ActivityDto activityDto)
        {
            if (activityDto == null)
                return BadRequest(ModelState);

            if (activityDto.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(activityDto.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in activityDto.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            Activity activity = _mapper.Map<Activity>(activityDto);
            activity.Subcategories = subcategories;

            if (!await _activityRepository.AddActivity(activity))
            {
                ModelState.AddModelError("error", "Database saving error");
                return StatusCode(500, ModelState);
            }

            return Ok ("Succesfully added");

        }

    }
}
