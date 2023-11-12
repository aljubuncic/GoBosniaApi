using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _dataContext;
        public ActivityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> ActivityExists(int id)
        {
            return await _dataContext.Accomodation.AnyAsync(a => a.Id == id);
        }

        public async Task<Activity> GetActivity(int id)
        {
            return await _dataContext.Activity.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Activity>> GetActivities()
        {
            return await _dataContext.Activity.ToListAsync();
        }
    }
}
