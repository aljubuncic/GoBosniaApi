using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IRatingRepository
    {
        public Task<List<Rating>> GetRatings();
        public Task<Rating> GetRating(int id);
        public Task<bool> RatingExists(int id);
        public Task<bool> AddRating(Rating rating);
        public Task<bool> UpdateRating(Rating rating);
        public Task<bool> Save();
    }
}
