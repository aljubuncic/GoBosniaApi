using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IActivityService : ITouristContentService<Activity, ActivityDtoRequest, ActivityDtoResponse>
    {
    }
}
