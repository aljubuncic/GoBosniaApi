using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GoTravnikApi.Repositories
{
    public class FoodAndDrinkRepository : TouristContentRepository<FoodAndDrink>, IFoodAndDrinkRepository
    {
        public FoodAndDrinkRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
