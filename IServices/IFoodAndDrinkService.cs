using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IFoodAndDrinkService : IRatedTouristContentService<FoodAndDrink, FoodAndDrinkDtoRequest, FoodAndDrinkDtoResponse>
    {
    }
}
