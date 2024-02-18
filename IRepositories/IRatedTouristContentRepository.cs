using GoTravnikApi.Models;

namespace GoTravnikApi.IRepositories
{
    public interface IRatedTouristContentRepository<Entity>
        : ITouristContentRepository<Entity> 
        where Entity: RatedTouristContent
    {
    }
}
