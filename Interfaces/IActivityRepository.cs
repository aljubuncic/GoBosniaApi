using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IActivityRepository
    {
        public Task<List<Activity>> GetActivities();
        public Task<List<Activity>> GetActivities(string searchName);
        public Task<Activity> GetActivity(int id);
        public Task<List<Activity>> FilterAndOrderActivities(List<string> subcategoryNames, string sortOption);
        public Task<bool> ActivityExists(int id);
        public Task<bool> AddActivity(Activity activity);

        public Task<bool> Save();
    }
}
