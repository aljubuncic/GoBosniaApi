using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IAccommodationService : ITouristContentService<Accommodation, AccommodationDtoRequest, AccommodationDtoResponse>
    {
    }
}
