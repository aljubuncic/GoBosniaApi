using GoTravnikApi.Models;

namespace GoTravnikApi.IRepositories
{
    public interface IEventRepository : ITouristContentRepository<Event>
    {
        public Task<List<Event>> FilterByDate(DateTime startDate, DateTime endDate);
    }
}
