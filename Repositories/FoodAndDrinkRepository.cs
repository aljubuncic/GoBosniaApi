using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GoTravnikApi.Repositories
{
    public class FoodAndDrinkRepository : IFoodAndDrinkRepository
    {
        private readonly DataContext _dataContext;
        public FoodAndDrinkRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddFoodAndDrink(FoodAndDrink foodAndDrink)
        {
            await _dataContext.Location.AddAsync(foodAndDrink.Location);

            await _dataContext.FoodAndDrink.AddAsync(foodAndDrink);

            return await Save();
        }

        public async Task<List<FoodAndDrink>> FilterAndOrderFoodAndDrinks(List<string> subcategoryNames, string sortOption)
        {
            var query = _dataContext.FoodAndDrink.AsQueryable();
            foreach (var subcategory in subcategoryNames)
                query = query.Where(fad => fad.Subcategories.Any(sub => sub.Name == subcategory) == true);

            if (sortOption == "alphabetical")
                query = query.OrderBy(fad => fad.Name);

            else if (sortOption == "popular")
                query = query.OrderByDescending(fad => fad.Ratings.Select(r => r.Value).Average());

            return await query
                .Include(fad => fad.Location)
                .Include(fad => fad.Ratings)
                .ToListAsync();
        }

        public async Task<bool> FoodAndDrinkExists(int id)
        {
            return await _dataContext.FoodAndDrink.AnyAsync(fad => fad.Id == id);
        }

        public async Task<FoodAndDrink> GetFoodAndDrink(int id)
        {
            return await _dataContext.FoodAndDrink
                .Where(fad => fad.Id == id)
                .Include(fad => fad.Ratings)
                .Include(fad => fad.Subcategories)
                .Include(fad => fad.Location)
                .FirstOrDefaultAsync();
        }

        public async Task<List<FoodAndDrink>> GetFoodAndDrinks()
        {
            return await _dataContext.FoodAndDrink
                .Include(x => x.Location)
                .Include(x => x.Ratings)
                .ToListAsync();
        }

        public async Task<List<FoodAndDrink>> GetFoodAndDrinks(string searchName)
        {
            return await _dataContext.FoodAndDrink.
                Where(a => a.Name.ToLower().Contains(searchName.ToLower()))
                .Include(x => x.Location)
                .Include(x => x.Ratings)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }

        public Task<bool> UpdateFoodAndDrink(FoodAndDrink foodAndDrink)
        {
            _dataContext.Update(foodAndDrink);
            return Save();
        }
    }
}
