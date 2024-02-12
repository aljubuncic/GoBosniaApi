using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IService<Entity, EntityRequestDto, EntityResponseDto>
        where Entity : class
        where EntityRequestDto : class
        where EntityResponseDto : class
    {
        public Task<List<EntityResponseDto>> GetAll();
        public Task<EntityResponseDto> GetById(int id);
        public Task<int> Add(EntityRequestDto entityRequestDto);
        public Task Delete(int id);

    }
}
