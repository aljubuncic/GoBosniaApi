using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetEvents();
        public Task<List<Event>> GetEvents(string searchName);

        public Task<Event> GetEvent(int id);

        public Task<List<Event>> GetEvents(DateTime startDate, DateTime endDate);
        
        public Task<bool> EventExists(int id);

        public Task<bool> AddEvent(Event _event);
        public Task<bool> Save();

    }
}
