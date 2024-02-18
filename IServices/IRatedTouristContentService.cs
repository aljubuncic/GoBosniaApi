using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IRatedTouristContentService<Entity, EntityRequestDto, EntityResponseDto>
        : ITouristContentService<Entity, EntityRequestDto, EntityResponseDto>
        where Entity : TouristContent
        where EntityRequestDto : TouristContentDtoRequest
        where EntityResponseDto : TouristContentDtoResponse
    {
        public Task<int> AddRating(int id, RatingDtoRequest ratingDtoRequest);
    }
}
