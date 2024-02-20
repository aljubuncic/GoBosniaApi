using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
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
    }
}
