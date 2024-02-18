using GoTravnikApi.Data;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
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
            try
            {
            return await _dataContext.Event
                .Where(e => e.StartDate >= startDate && e.EndDate <= endDate)
                .Include(e => e.Location)
                .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }
    }
}
