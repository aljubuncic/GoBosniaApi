using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IActivityRepository
    {
        public Task<List<Activity>> GetActivities();
        public Task<List<Activity>> GetActivities(string searchName);
        public Task<Activity> GetActivity(int id);
        public Task<bool> ActivityExists(int id);
    }
}
