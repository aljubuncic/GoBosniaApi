using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IAccommodationRepository
    {
        public Task<List<Accommodation>> GetAccomodations();
        public Task<Accommodation> GetAccommodation(int id);
        public Task<bool> AccomodationExists(int id);
    }
}
