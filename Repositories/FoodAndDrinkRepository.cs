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
    }
}
