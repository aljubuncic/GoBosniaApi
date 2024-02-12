using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface ILocationService : IService<Location, LocationDtoRequest,  LocationDtoResponse>
    {
    }
}
