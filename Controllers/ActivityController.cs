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
    [Route("api/activities")]
    [ApiController]
    public class ActivityController  
        : RatedTouristContentController<Activity, ActivityDtoRequest, ActivityDtoResponse>
    {
        private readonly IActivityService _activityService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IRatingService _ratingService;

        public ActivityController(IActivityService activityService, ISubcategoryService subcategoryService, IRatingService ratingService) 
            : base(activityService, subcategoryService, ratingService, "activities")
        {
            _activityService = activityService;
            _subcategoryService = subcategoryService;
            _ratingService = ratingService;
        }

        [HttpGet("sort/{sort_option}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ActivityDtoResponse>>> GetSortedAccommodations(string sort_option)
        {
            var activityResponseDtos = await _activityService.Sort(sort_option);

            return Ok(activityResponseDtos);
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ActivityDtoResponse>>> GetFilteredAccommodations([FromQuery] List<string> subcategory_names)
        {
            var activityResponseDtos = await _activityService.GetBySubcategories(subcategory_names);

            return Ok(activityResponseDtos);
        }

    }
}
