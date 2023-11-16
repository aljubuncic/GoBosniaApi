using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IFoodAndDrinkRepository
    {
        public Task<List<FoodAndDrink>> GetFoodAndDrinks();
        public Task<List<FoodAndDrink>> GetFoodAndDrinks(string searchName);
        public Task<FoodAndDrink> GetFoodAndDrink(int id);
        public Task<bool> FoodAndDrinkExists(int id);
        public Task<bool> AddFoodAndDrink(FoodAndDrink foodAndDrink);
        public Task<List<FoodAndDrink>> FilterAndOrderFoodAndDrinks(List<string> subcategoryNames, string sortOption);
        public Task<bool> Save();
    }
}
