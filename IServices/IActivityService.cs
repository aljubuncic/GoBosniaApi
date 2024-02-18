using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IActivityService : IRatedTouristContentService<Activity, ActivityDtoRequest, ActivityDtoResponse>
    {
    }
}