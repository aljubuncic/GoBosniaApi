using GoTravnikApi.Dto;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
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
        public AccommodationController(IAccommodationRepository accommodationRepository, ISubcategoryRepository subcategoryRepository)
        {
            _accommodationRepository = accommodationRepository;
            _subcategoryRepository = subcategoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Accommodation>))]
        public async Task<ActionResult<List<Accommodation>>> GetAccommodations()
        {
            var events = await _accommodationRepository.GetAccomodations();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Accommodation))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Accommodation>> GetAccommodation(int id)
        {
            if (!await _accommodationRepository.AccomodationExists(id))
                return NotFound(ModelState);
            var events = await _accommodationRepository.GetAccommodation(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<Accommodation>))]
        public async Task<ActionResult<List<Accommodation>>> GetAccommodations(string name)
        {
            var accommodations = await _accommodationRepository.GetAccomodations(name);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accommodations);
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
            Accommodation accommodation = new Accommodation(accommodationDto);
            accommodation.Subcategories = subcategories;

            if (!await _accommodationRepository.AddAccommodation(accommodation))
            { 
                ModelState.AddModelError("error", "Database saving error");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");

        }
    }
}
