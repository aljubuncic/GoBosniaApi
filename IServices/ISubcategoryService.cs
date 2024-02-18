using GoTravnikApi.Dto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface ISubcategoryService : IService<Subcategory, SubcategoryDtoRequest, SubcategoryDtoResponse>
    {
        public Task<SubcategoryDtoResponse> GetSubcategory(string name);
        public Task<bool> SubcategoriesExist(List<string> subcategoryNames);
    }
}
