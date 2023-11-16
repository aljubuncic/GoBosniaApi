using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : Controller
    {
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public AccommodationController(IAccommodationRepository accommodationRepository, ISubcategoryRepository subcategoryRepository, IRatingRepository ratingRepository, IMapper mapper)
        {
            _accommodationRepository = accommodationRepository;
            _subcategoryRepository = subcategoryRepository;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AccommodationDto>))]
        public async Task<ActionResult<List<AccommodationDto>>> GetAccommodations()
        {
            var accommodationDtos =_mapper.Map<List<AccommodationDto>> (await _accommodationRepository.GetAccomodations());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accommodationDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(AccommodationDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AccommodationDto>> GetAccommodation(int id)
        {
            if (!await _accommodationRepository.AccomodationExists(id))
                return NotFound(ModelState);
            var accommodationDto =_mapper.Map<AccommodationDto>(await _accommodationRepository.GetAccommodation(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accommodationDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<AccommodationDto>))]
        public async Task<ActionResult<List<AccommodationDto>>> GetAccommodations(string name)
        {
            var accommodationDtos = _mapper.Map<List<AccommodationDto>>(await _accommodationRepository.GetAccomodations(name));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accommodationDtos);
        }

        [HttpPost("{sortOption}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AccommodationDto>>> GetFilteredAndOrderedFoodAndDrinks([FromBody] List<string> subcategoryNames, string sortOption)
        {

            var accommodationDtos = _mapper.Map<List<AccommodationDto>>(await _accommodationRepository.FilterAndOrderAccommodations(subcategoryNames, sortOption));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accommodationDtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddAccommodation([FromBody] AccommodationDto accommodationDto)
        {
            if(accommodationDto == null)
                return BadRequest(ModelState);

            if (accommodationDto.Location == null)
                return BadRequest(ModelState);

            if(!await _subcategoryRepository.SubcategoriesExist(accommodationDto.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }
                
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach(var subcategoryDto in accommodationDto.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            Accommodation accommodation = _mapper.Map<Accommodation>(accommodationDto);
            accommodation.Subcategories = subcategories;

            if (!await _accommodationRepository.AddAccommodation(accommodation))
            { 
                ModelState.AddModelError("error", "Database saving error");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added");

        }

        [HttpPost("/rating/{accommodationId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddRating(int accommodationId, [FromBody] RatingDto ratingDto)
        {
            if (ratingDto == null)
                return BadRequest(ModelState);

            if(!await _accommodationRepository.AccomodationExists(accommodationId))
            {
                ModelState.AddModelError("error", "Accomoodation does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accommodation = await _accommodationRepository.GetAccommodation(accommodationId);
            var rating = _mapper.Map<Rating>(ratingDto);

            accommodation.Ratings.Add(rating);

            if (!await _ratingRepository.AddRating(rating))
            {
                ModelState.AddModelError("error", "Database updating error");
                return StatusCode(500, ModelState);
            }

            if (!await _accommodationRepository.UpdateAccommodation(accommodation))
            {
                ModelState.AddModelError("error", "Database updating error");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully added");

        }
    }
}
