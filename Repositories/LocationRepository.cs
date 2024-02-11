using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
