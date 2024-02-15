using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.Repositories
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
