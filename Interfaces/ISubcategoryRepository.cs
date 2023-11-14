using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface ISubcategoryRepository
    {
        public Task<bool> SubcategoriesExist(List<string> subcategoryNames);
        public Task<Subcategory> GetSubcategory(string name);
    }
}
