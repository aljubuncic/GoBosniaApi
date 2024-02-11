using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repository
{
    public class ActivityRepository : TouristContentRepository<Activity>,IActivityRepository
    {
        public ActivityRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
