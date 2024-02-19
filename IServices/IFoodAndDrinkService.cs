using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IFoodAndDrinkService : IRatedTouristContentService<FoodAndDrink, FoodAndDrinkDtoRequest, FoodAndDrinkDtoResponse>
    {
    }
}
