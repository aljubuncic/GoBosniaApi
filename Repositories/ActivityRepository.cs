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
            return await _dataContext.Activity.AnyAsync(a => a.Id == id);
        }

        public async Task<Activity> GetActivity(int id)
        {
            return await _dataContext.Activity.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Activity>> GetActivities()
        {
            return await _dataContext.Activity.ToListAsync();
        }

        public async Task<List<Activity>> GetActivities(string searchName)
        {
            return await _dataContext.Activity.Where(a => a.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
        }

        public async Task<bool> AddActivity(Activity activity)
        {
            await _dataContext.Location.AddAsync(activity.Location);

            await _dataContext.Activity.AddAsync(activity);

            return await Save();
        }
        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
