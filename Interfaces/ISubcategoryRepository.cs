using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface ISubcategoryRepository
    {
        public Task<bool> SubcategoriesExist(List<Subcategory> subcategories);
    }
}
