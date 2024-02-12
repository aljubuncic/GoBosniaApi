using GoTravnikApi.Dto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface ISubcategoryService : IService<Subcategory, SubcategoryDto, SubcategoryDto>
    {
        public Task<SubcategoryDto> GetSubcategory(string name);
        public Task<bool> SubcategoriesExist(List<string> subcategoryNames);
    }
}
