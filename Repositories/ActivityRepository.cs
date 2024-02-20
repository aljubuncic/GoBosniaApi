using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.Repositories
{
    public class ActivityRepository : RatedTouristContentRepository<Activity>,IActivityRepository
    {
        public ActivityRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
