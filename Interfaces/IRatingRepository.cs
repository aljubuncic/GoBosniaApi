using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IRatingRepository
    {
        public Task<List<Rating>> GetRatings();
        public Task<bool> AddRating(Rating rating);

        public Task<bool> Save();
    }
}
