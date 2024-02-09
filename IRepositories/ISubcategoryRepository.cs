using GoTravnikApi.Models;

namespace GoTravnikApi.IRepositories
{
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        public Task<bool> SubcategoriesExist(List<string> subcategoryNames);
        public Task<Subcategory?> GetSubcategory(string name);
    }
}
