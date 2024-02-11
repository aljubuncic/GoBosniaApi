using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Runtime.CompilerServices;

namespace GoTravnikApi.Repositories
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
