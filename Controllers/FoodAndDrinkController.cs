using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
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
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public FoodAndDrinkController(IFoodAndDrinkRepository foodAndDrinkRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _foodAndDrinkRepository = foodAndDrinkRepository;
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
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

        [HttpPost("{sortOption}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<FoodAndDrinkDto>>> GetFilteredAndOrderedFoodAndDrinks([FromBody] List<string> subcategoryNames, string sortOption)
        {

            var foodAndDrinkDtos = _mapper.Map<List<FoodAndDrinkDto>>(await _foodAndDrinkRepository.FilterAndOrderFoodAndDrinks(subcategoryNames, sortOption));
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddFoodAndDrink([FromBody] FoodAndDrinkDto foodAndDrinkDto)
        {
            if (foodAndDrinkDto == null)
                return BadRequest(ModelState);

            if (foodAndDrinkDto.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(foodAndDrinkDto.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in foodAndDrinkDto.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            FoodAndDrink foodAndDrink = _mapper.Map<FoodAndDrink>(foodAndDrinkDto);
            foodAndDrink.Subcategories = subcategories;

            if (!await _foodAndDrinkRepository.AddFoodAndDrink(foodAndDrink))
            {
                ModelState.AddModelError("error", "Database saving error");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added");

        }
    }
}
