using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.Repositories
{
    public class AttractionRepository : TouristContentRepository<Attraction>, IAttractionRepository
    {
        public AttractionRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
