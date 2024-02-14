using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class EventRepository : TouristContentRepository<Event>,IEventRepository
    {
        private readonly DataContext _dataContext;
        public EventRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Event>> FilterByDate(DateTime startDate, DateTime endDate)
        {
            return await _dataContext.Event
                .Where(e => e.StartDate >= startDate && e.EndDate <= endDate)
                .Include(e => e.Ratings)
                .Include(e => e.Location)
                .ToListAsync();
        }
    }
}
