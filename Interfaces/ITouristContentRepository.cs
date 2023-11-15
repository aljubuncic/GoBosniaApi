using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface ITouristContentRepository
    {
        public Task<TouristContent> GetTouristContent(int ratingId);
    }
}
