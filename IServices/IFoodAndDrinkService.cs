using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IFoodAndDrinkService : ITouristContentService<FoodAndDrink, FoodAndDrinkDtoRequest, FoodAndDrinkDtoResponse>
    {
    }
}
