using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IAccommodationService : IRatedTouristContentService<Accommodation, AccommodationDtoRequest, AccommodationDtoResponse>
    {
    }
}