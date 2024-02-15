using AutoMapper;
using GoTravnikApi.Dto;

using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodAndDrinkController 
        : TouristContentController<FoodAndDrink, FoodAndDrinkDtoRequest, FoodAndDrinkDtoResponse>
    {
        private readonly IFoodAndDrinkService _foodAndDrinkService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IRatingService _ratingService;

        public FoodAndDrinkController(IFoodAndDrinkService foodAndDrinkService, ISubcategoryService subcategoryService, IRatingService ratingService) : base(foodAndDrinkService, subcategoryService, ratingService)
        {
            _foodAndDrinkService = foodAndDrinkService;
            _subcategoryService = subcategoryService;
            _ratingService = ratingService;
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<FoodAndDrinkDtoResponse>>> GetFilteredAndOrderedFoodAndDrinks([FromQuery] List<string> subcategoryNames)
        {
            var foodAndDrinkDtoResponses = await _foodAndDrinkService.GetBySubcategories(subcategoryNames);
            
            return Ok(foodAndDrinkDtoResponses);
        }

        [HttpGet("sort/{sortOption}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<FoodAndDrinkDtoResponse>>> GetFilteredAndOrderedFoodAndDrinks([FromQuery] string sortOption)
        {
            var foodAndDrinkDtoResponses = await _foodAndDrinkService.Sort(sortOption);

            return Ok(foodAndDrinkDtoResponses);
        }
    }
}
