using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> FoodAndDrinkExists(int id)
        {
            return await _dataContext.FoodAndDrink.AnyAsync(fad => fad.Id == id);
        }

        public async Task<FoodAndDrink> GetFoodAndDrink(int id)
        {
            return await _dataContext.FoodAndDrink.Where(fad => fad.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<FoodAndDrink>> GetFoodAndDrinks()
        {
            return await _dataContext.FoodAndDrink.ToListAsync();
        }

        public async Task<List<FoodAndDrink>> GetFoodAndDrinks(string searchName)
        {
            return await _dataContext.FoodAndDrink.Where(a => a.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
