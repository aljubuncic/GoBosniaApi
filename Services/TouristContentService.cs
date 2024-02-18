using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public abstract class TouristContentService<Entity, EntityRequestDto, EntityResponseDto> 
        : Service<Entity, EntityRequestDto, EntityResponseDto>, 
        ITouristContentService<Entity, EntityRequestDto, EntityResponseDto>
        where Entity : TouristContent
        where EntityRequestDto : TouristContentDtoRequest
        where EntityResponseDto : TouristContentDtoResponse
    {
        private readonly ITouristContentRepository<Entity> _touristContentRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public TouristContentService(ITouristContentRepository<Entity> touristContentRepository, ISubcategoryRepository subcategoryRepository,IMapper mapper): base(touristContentRepository, mapper)
        {
            _touristContentRepository = touristContentRepository;
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }
        public new async Task<int> Add(EntityRequestDto entityRequestDto)
        {
            try
            {
                var subcategoryNames = entityRequestDto.Subcategories.Select(x => x.Name).ToList();
                if (!await _subcategoryRepository.SubcategoriesExist(subcategoryNames))
                    throw new NotFoundException("All subcategories must be present in the database");

                var touristContent = _mapper.Map<Entity>(entityRequestDto);
                var addedTouristContentId = await _touristContentRepository.Add(touristContent);
                return addedTouristContentId;
            }
            catch (InternalServerErrorException)
            {
                throw;
            }
        }
        public async Task<List<EntityResponseDto>> GetByName(string name)
        {
            try
            {
                var touristContentDtoResponses = _mapper.Map<List<EntityResponseDto>>(await _touristContentRepository.GetByName(name));
                return touristContentDtoResponses;
            }
            catch (InternalServerErrorException)
            {
                throw;
            }
        }

        public async Task<List<EntityResponseDto>> GetBySubcategories(List<string> subcategoryNames)
        {
            try
            {
                var touristContentDtoResponses = _mapper.Map<List<EntityResponseDto>>(await _touristContentRepository.FilterBySubcategories(subcategoryNames));
                return touristContentDtoResponses;
            }
            catch (InternalServerErrorException)
            {
                throw;
            }
        }

        public async Task<List<EntityResponseDto>> Sort(string sortOption)
        {
            try
            {
                var touristContentDtoResponses = _mapper.Map<List<EntityResponseDto>>(await _touristContentRepository.Sort(sortOption));
                return touristContentDtoResponses;
            }
            catch (InternalServerErrorException)
            {
                throw;
            }
        }
    }
}
