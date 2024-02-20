using GoTravnikApi.Models;

namespace GoTravnikApi.IRepositories
{
    public interface ITouristContentRepository<Entity> : IRepository<Entity> where Entity : TouristContent
    {
        public Task<List<Entity>> GetByName(string name);
        public Task<List<Entity>> FilterBySubcategories(List<string> subcategoryNames);
        public Task<List<Entity>> SortByName(string sort_order);
    }
}
