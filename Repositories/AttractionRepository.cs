using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class AttractionRepository : TouristContentRepository<Attraction>, IAttractionRepository
    {
        public AttractionRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
