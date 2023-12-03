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
        [ProducesResponseType(200, Type = typeof(List<AttractionDtoResponse>))]
        public async Task<ActionResult<List<AttractionDtoResponse>>> GetAttractions()
        {
            var attractionDtos = _mapper.Map<List<AttractionDtoResponse>>(await _attractionRepository.GetAttractions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(AttractionDtoResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AttractionDtoResponse>> GetActivity(int id)
        {
            if (!await _attractionRepository.AttractionExists(id))
                return NotFound(ModelState);
            var attractionDto = _mapper.Map<AttractionDtoResponse>(await _attractionRepository.GetAttraction(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<AttractionDtoResponse>))]
        public async Task<ActionResult<List<AttractionDtoResponse>>> GetAttractions(string name)
        {
            var attractionDtos = _mapper.Map<List<AttractionDtoResponse>>(await _attractionRepository.GetAttractions(name));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDtos);
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AttractionDtoResponse>>> GetFilteredAttractions([FromQuery] List<string> subcategory)
        {

            var attractionDtos = _mapper.Map<List<AttractionDtoResponse>>(await _attractionRepository
                .FilterAttractions(subcategory));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(attractionDtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddAttraction([FromBody] AttractionDtoRequest attractionDtoRequest)
        {
            if (attractionDtoRequest == null)
                return BadRequest(ModelState);

            if (attractionDtoRequest.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(attractionDtoRequest.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in attractionDtoRequest.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            Attraction attraction = _mapper.Map<Attraction>(attractionDtoRequest);
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
