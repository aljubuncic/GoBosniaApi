using AutoMapper;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

namespace GoTravnikApi.Services
{
    public abstract class Service<Entity, EntityRequestDto, EntityResponseDto>
        : IService<Entity, EntityRequestDto, EntityResponseDto>
        where Entity : class
        where EntityRequestDto : class
        where EntityResponseDto : class
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public Service(IRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Add(EntityRequestDto touristContentDtoRequest)
        {
            var touristContent = _mapper.Map<Entity>(touristContentDtoRequest);
            try 
            {
                var addedEntityId = await _repository.Add(touristContent);
                return addedEntityId;
            }
            catch(InternalServerErrorException)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            var touristContent = await _repository.GetById(id) ?? throw new NotFoundException($"Entity with id \'{id}\' does not exist in the database");
            try
            {
                await _repository.Delete(touristContent);
            }
            catch (InternalServerErrorException)
            {
                throw;
            }
        }

        public async Task<List<EntityResponseDto>> GetAll()
        {
            try
            {
                var touristContentDtoResponses = _mapper.Map<List<EntityResponseDto>>(await _repository.GetAll());

                return touristContentDtoResponses;
            }
            catch(InternalServerErrorException)
            {
                throw;
            }

        }

        public async Task<EntityResponseDto> GetById(int id)
        {
            try
            {
                var touristContent = await _repository.GetById(id) ?? throw new NotFoundException($"Entity with id \'{id}\' does not exist in the database");
                var touristContentDtoResponse = _mapper.Map<EntityResponseDto>(touristContent);
                return touristContentDtoResponse;
            }
            catch(InternalServerErrorException)
            {
                throw;
            }
        }
    }
}
