using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IAccommodationRepository
    {
        public Task<List<Accommodation>> GetAccomodations();
        public Task<List<Accommodation>> GetAccomodations(string searchName);
        public Task<Accommodation> GetAccommodation(int id);
        public Task<List<Accommodation>> FilterAndOrderAccommodations(List<string> subcategoryNames, string sortOption);
        public Task<bool> AccomodationExists(int id);

        public Task<bool> AddAccommodation(Accommodation accommodation);
        public Task<bool> UpdateAccommodation(Accommodation accommodation);

        public Task<bool> Save();
    }
}
