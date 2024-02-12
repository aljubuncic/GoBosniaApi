using GoTravnikApi.Dto;
using GoTravnikApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.IServices
{
    public interface ITouristContentService<Entity, EntityRequestDto, EntityResponseDto>
        : IService<Entity, EntityRequestDto, EntityResponseDto>
        where Entity : TouristContent
        where EntityRequestDto : TouristContentDtoRequest
        where EntityResponseDto : TouristContentDtoResponse
    {
        public Task<List<EntityResponseDto>> GetByName(string name);
        public Task<List<EntityResponseDto>> GetBySubcategories(List<string> subcategoryNames);
        public Task<List<EntityResponseDto>> Sort(string sortOption);
        public new Task<int> Add(EntityRequestDto entityRequestDto);
        public Task<int> AddRating(int id, RatingDtoRequest ratingDtoRequest);
    }
}