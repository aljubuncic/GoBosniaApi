using GoTravnikApi.Data;
using GoTravnikApi.Dto;
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
            return await _dataContext.Accommodation.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> AddAccommodation(Accommodation accommodation)
        {
            await _dataContext.AddAsync(accommodation.Location);

            await _dataContext.AddAsync(accommodation);

            return await Save();
        }

        public async Task<List<Accommodation>> FilterAndOrderAccommodations(List<string> subcategoryNames, string sortOption)
        {
            var query = _dataContext.Accommodation.AsQueryable();
            foreach (var subcategory in subcategoryNames)
                query = query.Where(a => a.Subcategories.Any(sub => sub.Name == subcategory) == true);

            if (sortOption == "alphabetical")
                query = query.OrderBy(a => a.Name);

            else if (sortOption == "popular")
                query = query.OrderByDescending(a => a.Ratings.Select(r => r.Value).Average());

            return await query
                .Include(a => a.Location)
                .Include(a => a.Ratings)
                .ToListAsync();
        }

        public async Task<Accommodation> GetAccommodation(int id)
        {
            return await _dataContext.Accommodation
                .Where(a => a.Id == id)
                .Include(a => a.Location)
                .Include(a => a.Ratings)
                .Include(a => a.Subcategories)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Accommodation>> GetAccomodations()
        {
            return await _dataContext.Accommodation
            .Include(x => x.Location)
            .Include(x => x.Ratings)
            .Include(x => x.Subcategories)
            .ToListAsync();
        }

        public async Task<List<Accommodation>> GetAccomodations(string searchName)
        {
            return await _dataContext.Accommodation
                .Where(a => a.Name.ToLower().Contains(searchName.ToLower()))
                .Include(x => x.Location)
                .Include(x => x.Ratings)
                .Include(x => x.Subcategories)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }

        public Task<bool> UpdateAccommodation(Accommodation accommodation)
        {
            _dataContext.Update(accommodation);
            return Save();
        }
    }
}
