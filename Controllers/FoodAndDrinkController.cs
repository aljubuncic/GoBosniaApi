using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodAndDrinkController : ControllerBase
    {
        private readonly IFoodAndDrinkRepository _foodAndDrinkRepository;
        public FoodAndDrinkController(IFoodAndDrinkRepository foodAndDrinkRepository)
        {
            _foodAndDrinkRepository = foodAndDrinkRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<FoodAndDrink>))]
        public async Task<ActionResult<List<FoodAndDrink>>> GetFoodAndDrinks()
        {
            var events = await _foodAndDrinkRepository.GetFoodAndDrinks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{foodAndDrinkId}")]
        [ProducesResponseType(200, Type = typeof(FoodAndDrink))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FoodAndDrink>> GetFoodAndDrink(int foodAndDrinkId)
        {
            if (!await _foodAndDrinkRepository.FoodAndDrinkExists(foodAndDrinkId))
                return NotFound(ModelState);
            var events = await _foodAndDrinkRepository.GetFoodAndDrink(foodAndDrinkId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }
    }
}
