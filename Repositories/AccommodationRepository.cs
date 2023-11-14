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
            return await _dataContext.Accomodation.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> AddAccommodation(Accommodation accommodation, List<Subcategory> subcategories)
        {
            await _dataContext.AddAsync(accommodation.Location);

            foreach(var subcategory in subcategories)
            {
                var touristContentSubcategory = new TouristContentSubcategory(accommodation, subcategory);
                await _dataContext.AddAsync(touristContentSubcategory);
            }

            await _dataContext.AddAsync(accommodation);

            return await Save();
        }

        public async Task<Accommodation> GetAccommodation(int id)
        {
            return await _dataContext.Accomodation.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Accommodation>> GetAccomodations()
        {
            var res = await _dataContext.Accomodation.Include(x => x.Location).Include(x => x.Ratings).ToListAsync();

            foreach (var accommodation in res)
            {
                var listSubCatIds = accommodation.touristContentSubcategories.Select(accommodation => accommodation.Id).ToList();
                var subcategories = await _dataContext.Subcategory.Where(x => listSubCatIds.Contains(x.Id)).ToListAsync();
                accommodation.SubCategoryList = subcategories;
            } 

            
        }

        public async Task<List<Accommodation>> GetAccomodations(string searchName)
        {
            return await _dataContext.Accomodation.Where(a => a.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved =await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
