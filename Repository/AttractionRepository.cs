using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repository
{
    public class AttractionRepository : IAttractionRepository
    {
        private readonly DataContext _dataContext;
        public AttractionRepository(DataContext dataContext)
        { 
            _dataContext = dataContext;
        }
        public async Task<bool> AttractionExists(int id)
        {
            return await _dataContext.Attraction.AnyAsync(a => a.Id == id); 
        }

        public async Task<Attraction> GetAttraction(int id)
        {
            return await _dataContext.Attraction.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Attraction>> GetAttractions()
        {
            return await _dataContext.Attraction.ToListAsync();
        }
    }
}
