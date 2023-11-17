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
            return await _dataContext.Attraction
                .Where(a => a.Id == id)
                .Include(a => a.Location)
                .Include(a => a.Ratings)
                .Include(a => a.Subcategories)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Attraction>> GetAttractions()
        {
            return await _dataContext.Attraction
                .Include(a => a.Location)
                .Include(a => a.Ratings)
                .ToListAsync();
        }

        public async Task<List<Attraction>> GetAttractions(string searchName)
        {
            return await _dataContext.Attraction
                .Where(a => a.Name.ToLower().Contains(searchName.ToLower()))
                .Include(a => a.Location)
                .Include(a => a.Ratings)
                .ToListAsync();
        }
        public async Task<bool> AddAttraction(Attraction attraction)
        {
            await _dataContext.Location.AddAsync(attraction.Location);

            await _dataContext.Attraction.AddAsync(attraction);

            return await Save();
        }
        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
