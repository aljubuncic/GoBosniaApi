using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public class FoodAndDrinkService
        : TouristContentService<FoodAndDrink, FoodAndDrinkDtoRequest, FoodAndDrinkDtoResponse>, IFoodAndDrinkService
    {
        public FoodAndDrinkService(IFoodAndDrinkRepository foodAndDrinkRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper) : base(foodAndDrinkRepository, subcategoryRepository, mapper)
        {
        }
    }
}
