using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.Repositories
{
    public class AccommodationRepository : TouristContentRepository<Accommodation>, IAccommodationRepository
    {
        public AccommodationRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
