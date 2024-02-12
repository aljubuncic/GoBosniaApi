using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IAttractionService : ITouristContentService<Attraction, AttractionDtoRequest, AttractionDtoResponse>
    {
    }
}
