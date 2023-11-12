using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repository
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly DataContext _dataContext;
        public AccommodationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AccomodationExists(int id)
        {
            return await _dataContext.Accomodation.AnyAsync(a => a.Id == id);
        }

        public async Task<Accommodation> GetAccommodation(int id)
        {
            return await _dataContext.Accomodation.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Accommodation>> GetAccomodations()
        {
            return await _dataContext.Accomodation.ToListAsync();
        }
    }
}
