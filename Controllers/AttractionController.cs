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
    public class AttractionController : Controller
    {
        private readonly IAttractionRepository _attractionRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public AttractionController(IAttractionRepository attractionRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper) {
            _attractionRepository = attractionRepository;
            _subcategoryRepository = subcategoryRepository; 
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AttractionDto>))]
        public async Task<ActionResult<List<AttractionDto>>> GetAttractions()
        {
            var attractionDtos = _mapper.Map<List<AttractionDto>>(await _attractionRepository.GetAttractions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(AttractionDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ActivityDto>> GetActivity(int id)
        {
            if (!await _attractionRepository.AttractionExists(id))
                return NotFound(ModelState);
            var attractionDto = _mapper.Map<AttractionDto>(await _attractionRepository.GetAttraction(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<AttractionDto>))]
        public async Task<ActionResult<List<AttractionDto>>> GetAttractions(string name)
        {
            var attractionDtos = _mapper.Map<List<AttractionDto>>(await _attractionRepository.GetAttractions(name));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDtos);
        }

        [HttpPost("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AttractionDto>>> GetFilteredAttractions([FromBody] List<string> subcategoryNames)
        {

            var attractionDtos = _mapper.Map<List<AttractionDto>>(await _attractionRepository
                .FilterAttractions(subcategoryNames));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddAttraction([FromBody] AttractionDto attractionDto)
        {
            if (attractionDto == null)
                return BadRequest(ModelState);

            if (attractionDto.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(attractionDto.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in attractionDto.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            Attraction attraction = _mapper.Map<Attraction>(attractionDto);
            attraction.Subcategories = subcategories;

            if (!await _attractionRepository.AddAttraction(attraction))
            {
                ModelState.AddModelError("error", "Database saving error");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added");

        }
    }
}
