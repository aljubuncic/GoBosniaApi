using GoTravnikApi.Models;

namespace GoTravnikApi.IRepositories
{
    public interface IRatedTouristContentRepository<Entity>
        : ITouristContentRepository<Entity> 
        where Entity: RatedTouristContent
    {
        public Task<List<Entity>> SortByAverageRating(string sort_order);
    }
}
