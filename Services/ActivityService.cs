using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public class ActivityService
        : RatedTouristContentService<Activity, ActivityDtoRequest, ActivityDtoResponse>, IActivityService
    {
        public ActivityService(IActivityRepository activityRepository, ISubcategoryRepository subcategoryRepository,IMapper mapper) : base(activityRepository, subcategoryRepository,mapper)
        {
        }
    }
}
