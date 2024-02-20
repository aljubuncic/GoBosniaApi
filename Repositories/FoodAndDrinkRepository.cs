using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;

namespace GoTravnikApi.Repositories
{
    public class FoodAndDrinkRepository : RatedTouristContentRepository<FoodAndDrink>, IFoodAndDrinkRepository
    {
        public FoodAndDrinkRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
