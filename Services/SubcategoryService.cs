using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public class SubcategoryService : Service<Subcategory, SubcategoryDto, SubcategoryDto>, ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public SubcategoryService(ISubcategoryRepository subcategoryRepository, IMapper mapper): base(subcategoryRepository,mapper)
        {
        }
        public async Task<SubcategoryDto> GetSubcategory(string name)
        {
            var subcategory = await _subcategoryRepository.GetSubcategory(name) ?? throw new NotFoundException($"Subcategory with name {name} does not exist in the database");
            var subcategoryResponseDto = _mapper.Map<SubcategoryDto>(subcategory);  
            return subcategoryResponseDto;
        }

        public async Task<bool> SubcategoriesExist(List<string> subcategoryNames)
        {
            return await _subcategoryRepository.SubcategoriesExist(subcategoryNames);
        }
    }
}
