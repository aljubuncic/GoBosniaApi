using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IActivityService : IRatedTouristContentService<Activity, ActivityDtoRequest, ActivityDtoResponse>
    {
    }
}