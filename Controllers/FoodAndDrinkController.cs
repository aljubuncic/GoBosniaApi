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

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<FoodAndDrinkDtoResponse>>> GetFilteredAndOrderedFoodAndDrinks([FromQuery] List<string> subcategory_names)
        {
            var foodAndDrinkDtoResponses = await _foodAndDrinkService.GetBySubcategories(subcategory_names);
            
            return Ok(foodAndDrinkDtoResponses);
        }

        [HttpGet("sort/{sort_option}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<FoodAndDrinkDtoResponse>>> GetFilteredAndOrderedFoodAndDrinks([FromQuery] string sort_option)
        {
            var foodAndDrinkDtoResponses = await _foodAndDrinkService.Sort(sort_option);

            return Ok(foodAndDrinkDtoResponses);
        }
    }
}
