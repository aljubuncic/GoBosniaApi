using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IRatingRepository
    {
        public Task<bool> AddRating(Rating rating);

        public Task<bool> Save();
    }
}
