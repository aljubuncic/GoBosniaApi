using GoTravnikApi.Models;

namespace GoTravnikApi.IRepositories
{
    public interface IRatingRepository : IRepository<Rating>
    {
        public Task<List<Rating>> GetUnapproved();
    }
}
