using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _dataContext;
        public EventRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> EventExists(int id)
        {
            return await _dataContext.Event.AnyAsync(e => e.Id == id);
        }

        public async Task<Event> GetEvent(int id)
        {
            return await _dataContext.Event.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _dataContext.Event.ToListAsync();
        }

        public async Task<List<Event>> GetEvents(DateTime startDate, DateTime endDate)
        {
            return await _dataContext.Event.Where(e => e.startDate >= startDate && e.endDate <= endDate).ToListAsync();
        }

        public async Task<List<Event>> GetEvents(string searchName)
        {
            return await _dataContext.Event.Where(a => a.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
        }
    }
}
