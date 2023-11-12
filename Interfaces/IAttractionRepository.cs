using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IAttractionRepository
    {
        public Task<List<Attraction>> GetAttractions();
        public Task<List<Attraction>> GetAttractions(string searchName);
        public Task<Attraction> GetAttraction(int id);
        public Task<bool> AttractionExists(int id);
    }
}
