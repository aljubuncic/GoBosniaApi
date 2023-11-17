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
            return await _dataContext.Event
                .Where(e => e.Id == id)
                .Include(e => e.Location)
                .Include(e => e.Ratings)
                .Include(e => e.Subcategories)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _dataContext.Event
                .Include(a => a.Location)
                .Include(a => a.Ratings)
                .ToListAsync();
        }

        public async Task<List<Event>> GetEvents(DateTime startDate, DateTime endDate)
        {
            return await _dataContext.Event
                .Where(e => e.startDate >= startDate && e.endDate <= endDate)
                .Include(e => e.Ratings)
                .Include(e => e.Location)
                .ToListAsync();
        }

        public async Task<List<Event>> GetEvents(string searchName)
        {
            return await _dataContext.Event
                .Where(a => a.Name.ToLower().Contains(searchName.ToLower()))
                .Include(a => a.Ratings)
                .Include(a => a.Location)
                .ToListAsync();
        }

        public async Task<bool> AddEvent(Event _event)
        {
            await _dataContext.Location.AddAsync(_event.Location);

            await _dataContext.Event.AddAsync(_event);

            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }

    }
}
