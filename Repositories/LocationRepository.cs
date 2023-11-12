using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _dataContext;

        public LocationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddLocation(Location location)
        {
            await _dataContext.AddAsync(location);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
