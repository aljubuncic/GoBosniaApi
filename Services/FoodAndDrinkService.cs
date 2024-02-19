using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public class FoodAndDrinkService
        : RatedTouristContentService<FoodAndDrink, FoodAndDrinkDtoRequest, FoodAndDrinkDtoResponse>, IFoodAndDrinkService
    {
        public FoodAndDrinkService(IFoodAndDrinkRepository foodAndDrinkRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper) : base(foodAndDrinkRepository, subcategoryRepository, mapper)
        {
        }
    }
}
