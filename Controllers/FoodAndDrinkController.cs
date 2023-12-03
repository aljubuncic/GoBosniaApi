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
        [ProducesResponseType(200, Type = typeof(List<FoodAndDrinkDtoResponse>))]
        public async Task<ActionResult<List<FoodAndDrinkDtoResponse>>> GetFoodAndDrinks()
        {
            var foodAndDrinkDtos = _mapper.Map<List<FoodAndDrinkDtoResponse>>(await _foodAndDrinkRepository.GetFoodAndDrinks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(FoodAndDrinkDtoResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FoodAndDrinkDtoResponse>> GetFoodAndDrink(int id)
        {
            if (!await _foodAndDrinkRepository.FoodAndDrinkExists(id))
                return NotFound(ModelState);
            var foodAndDrinkDto = _mapper.Map<FoodAndDrinkDtoResponse>(await _foodAndDrinkRepository.GetFoodAndDrink(id));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<FoodAndDrinkDtoResponse>))]
        public async Task<ActionResult<List<FoodAndDrinkDtoResponse>>> GetFoodAndDrinks(string name)
        {
            var foodAndDrinkDtos = _mapper.Map<List<FoodAndDrinkDtoResponse>>(await _foodAndDrinkRepository.GetFoodAndDrinks(name));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDtos);
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<FoodAndDrinkDtoResponse>>> GetFilteredAndOrderedFoodAndDrinks([FromQuery] List<string> subcategory, [FromQuery] string? sortOption)
        {

            var foodAndDrinkDtos = _mapper.Map<List<FoodAndDrinkDtoResponse>>(await _foodAndDrinkRepository.FilterAndOrderFoodAndDrinks(subcategory, sortOption));
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(foodAndDrinkDtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddFoodAndDrink([FromBody] FoodAndDrinkDtoRequest foodAndDrinkDtoRequest)
        {
            if (foodAndDrinkDtoRequest == null)
                return BadRequest(ModelState);

            if (foodAndDrinkDtoRequest.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(foodAndDrinkDtoRequest.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in foodAndDrinkDtoRequest.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            FoodAndDrink foodAndDrink = _mapper.Map<FoodAndDrink>(foodAndDrinkDtoRequest);
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
        public async Task<ActionResult> AddRating(int foodAndDrinkId, [FromBody] RatingDtoRequest ratingDtoRequest)
        {
            if (ratingDtoRequest == null)
                return BadRequest(ModelState);

            if (!await _foodAndDrinkRepository.FoodAndDrinkExists(foodAndDrinkId))
            {
                ModelState.AddModelError("error", "FoodAndDrink does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var foodAndDrink = await _foodAndDrinkRepository.GetFoodAndDrink(foodAndDrinkId);
            var rating = _mapper.Map<Rating>(ratingDtoRequest);
            
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
