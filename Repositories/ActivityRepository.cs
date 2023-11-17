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
            return await _dataContext.Activity.Where(a => a.Id == id)
                .Include(a => a.Subcategories)
                .Include(a => a.Ratings)
                .Include(a => a.Location)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Activity>> GetActivities()
        {
            return await _dataContext.Activity
                .Include(a => a.Ratings)
                .Include(a => a.Location)
                .ToListAsync();
        }

        public async Task<List<Activity>> GetActivities(string searchName)
        {
            return await _dataContext.Activity
                .Where(a => a.Name.ToLower().Contains(searchName.ToLower()))
                .Include(a => a.Ratings)
                .Include(a => a.Location)
                .ToListAsync();
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

        public async Task<List<Activity>> FilterAndOrderActivities(List<string> subcategoryNames, string sortOption)
        {
            var query = _dataContext.Activity.AsQueryable();
            foreach (var subcategory in subcategoryNames)
                query = query.Where(a => a.Subcategories.Any(sub => sub.Name == subcategory) == true);

            if (sortOption == "alphabetical")
                query = query.OrderBy(a => a.Name);

            else if (sortOption == "popular")
                query = query.OrderByDescending(a => a.Ratings.Select(r => r.Value).Average());

            return await query
                .Include(a => a.Location)
                .Include(a => a.Ratings)
                .ToListAsync();
        }

        public Task<bool> UpdateActivity(Activity activity)
        {
            _dataContext.Update(activity);
            return Save();
        }
    }
}
