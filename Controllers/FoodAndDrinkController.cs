using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using GoTravnikApi.Repository;
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

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(FoodAndDrink))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FoodAndDrink>> GetFoodAndDrink(int id)
        {
            if (!await _foodAndDrinkRepository.FoodAndDrinkExists(id))
                return NotFound(ModelState);
            var foodAndDrinks = await _foodAndDrinkRepository.GetFoodAndDrink(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinks);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<FoodAndDrink>))]
        public async Task<ActionResult<List<FoodAndDrink>>> GetFoodAndDrinks(string name)
        {
            var foodAndDrinks = await _foodAndDrinkRepository.GetFoodAndDrinks(name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinks);
        }
    }
}
