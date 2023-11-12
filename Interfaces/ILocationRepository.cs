using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface ILocationRepository
    {
        public Task<bool> AddLocation(Location location);

        public Task<bool> Save();
    }
}
