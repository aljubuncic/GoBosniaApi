using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/food_and_drinks")]
    [ApiController]
    public class FoodAndDrinkController 
        : RatedTouristContentController<FoodAndDrink, FoodAndDrinkDtoRequest, FoodAndDrinkDtoResponse>
    {
        private readonly IFoodAndDrinkService _foodAndDrinkService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IRatingService _ratingService;

        public FoodAndDrinkController(IFoodAndDrinkService foodAndDrinkService, ISubcategoryService subcategoryService, IRatingService ratingService) 
            : base(foodAndDrinkService, subcategoryService, ratingService, "food_and_drinks")
        {
            _foodAndDrinkService = foodAndDrinkService;
            _subcategoryService = subcategoryService;
            _ratingService = ratingService;
        }
    }
}
