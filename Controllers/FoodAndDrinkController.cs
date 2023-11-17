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
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public FoodAndDrinkController(IFoodAndDrinkRepository foodAndDrinkRepository, ISubcategoryRepository subcategoryRepository, IRatingRepository ratingRepository, IMapper mapper)
        {
            _foodAndDrinkRepository = foodAndDrinkRepository;
            _subcategoryRepository = subcategoryRepository;
            _foodAndDrinkRepository = foodAndDrinkRepository;
            _ratingRepository = ratingRepository;   
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<FoodAndDrinkDto>))]
        public async Task<ActionResult<List<FoodAndDrinkDto>>> GetFoodAndDrinks()
        {
            var foodAndDrinkDtos = _mapper.Map<List<FoodAndDrinkDto>>(await _foodAndDrinkRepository.GetFoodAndDrinks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(FoodAndDrinkDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FoodAndDrinkDto>> GetFoodAndDrink(int id)
        {
            if (!await _foodAndDrinkRepository.FoodAndDrinkExists(id))
                return NotFound(ModelState);
            var foodAndDrinkDto = _mapper.Map<FoodAndDrinkDto>(await _foodAndDrinkRepository.GetFoodAndDrink(id));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<FoodAndDrinkDto>))]
        public async Task<ActionResult<List<FoodAndDrinkDto>>> GetFoodAndDrinks(string name)
        {
            var foodAndDrinkDtos = _mapper.Map<List<FoodAndDrinkDto>>(await _foodAndDrinkRepository.GetFoodAndDrinks(name));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDtos);
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

        [HttpPost("rating/{foodAndDrinkId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddRating(int foodAndDrinkId, [FromBody] RatingDtoRequest ratingDto)
        {
            if (ratingDto == null)
                return BadRequest(ModelState);

            if (!await _foodAndDrinkRepository.FoodAndDrinkExists(foodAndDrinkId))
            {
                ModelState.AddModelError("error", "FoodAndDrink does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var foodAndDrink = await _foodAndDrinkRepository.GetFoodAndDrink(foodAndDrinkId);
            var rating = _mapper.Map<Rating>(ratingDto);
            Console.WriteLine($"Mapped Rating: Id={rating.Id}, Value={rating.Value}, ...");
            foodAndDrink.Ratings.Add(rating);

            if (!await _ratingRepository.AddRating(rating))
            {
                ModelState.AddModelError("error", "Database updating error");
                return StatusCode(500, ModelState);
            }

            if (!await _foodAndDrinkRepository.UpdateFoodAndDrink(foodAndDrink))
            {
                ModelState.AddModelError("error", "Database updating error");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully added");

        }
    }
}
