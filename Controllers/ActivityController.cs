using AutoMapper;
using GoTravnikApi.Dto;

using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

using GoTravnikApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : 
        TouristContentController<Activity, ActivityDtoRequest, ActivityDtoResponse>
    {
        private readonly IActivityService _activityService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IRatingService _ratingService;

        public ActivityController(IActivityService activityService, ISubcategoryService subcategoryService, IRatingService ratingService) : base(activityService, subcategoryService, ratingService)
        {
            _activityService = activityService;
            _subcategoryService = subcategoryService;
            _ratingService = ratingService;
        }

        [HttpGet("sort/{sortOption}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<ActivityDtoResponse>>> GetSortedAccommodations(string sortOption)
        {
            var activityResponseDtos = await _activityService.Sort(sortOption);

            return Ok(activityResponseDtos);
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<ActivityDtoResponse>>> GetFilteredAccommodations([FromQuery] List<string> subcategoryNames)
        {
            var activityResponseDtos = await _activityService.GetBySubcategories(subcategoryNames);

            return Ok(activityResponseDtos);
        }

    }
}
