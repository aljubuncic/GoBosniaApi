using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.Repositories
{
    public class RatedTouristContentRepository<Entity>
        : TouristContentRepository<Entity>, IRatedTouristContentRepository<Entity>
        where Entity : RatedTouristContent
    {
        public RatedTouristContentRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
