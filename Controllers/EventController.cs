using AutoMapper;
using GoTravnikApi.Data;
using GoTravnikApi.Dto;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
using GoTravnikApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public EventController(IEventRepository eventRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper) { 
            _eventRepository = eventRepository;
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EventDto>))]
        public async Task<ActionResult<List<EventDto>>> GetEvents() 
        {
            var eventDtos = _mapper.Map<List<EventDto>>(await _eventRepository.GetEvents());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(eventDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(EventDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            if(!await _eventRepository.EventExists(id)) 
                return NotFound(ModelState);
            var eventDto = _mapper.Map<EventDto>(await _eventRepository.GetEvent(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<Event>))]
        public async Task<ActionResult<List<Event>>> GetEvents(string name)
        {
            var eventDtos = _mapper.Map<List<EventDto>>(await _eventRepository.GetEvents(name));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventDtos);
        }

        [HttpPost("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<EventDto>>> GetFilteredEvents([FromBody] EventTripPlannerDto eventTripPlannerDto)
        {

            var eventDtos = _mapper.Map<List<EventDto>>(await _eventRepository
                .FilterEvents(eventTripPlannerDto.SubcategoryNames, eventTripPlannerDto.StartDate, eventTripPlannerDto.EndDate));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventDtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddEvent([FromBody] EventDto eventDto)
        {
            if (eventDto == null)
                return BadRequest(ModelState);

            if (eventDto.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(eventDto.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in eventDto.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            Event _event = _mapper.Map<Event>(eventDto);
            _event.Subcategories = subcategories;

            if (!await _eventRepository.AddEvent(_event))
            {
                ModelState.AddModelError("error", "Database saving error");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added");

        }
    }
}
