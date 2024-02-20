using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
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
        public Task<List<EntityResponseDto>> SortByName(string sortOrder);
        public new Task<int> Add(EntityRequestDto entityRequestDto);
    }
}