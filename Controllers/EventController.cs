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
        [ProducesResponseType(200, Type = typeof(List<EventDtoResponse>))]
        public async Task<ActionResult<List<EventDtoResponse>>> GetEvents() 
        {
            var eventDtos = _mapper.Map<List<EventDtoResponse>>(await _eventRepository.GetEvents());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(eventDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(EventDtoResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<EventDtoResponse>> GetEvent(int id)
        {
            if(!await _eventRepository.EventExists(id)) 
                return NotFound(ModelState);
            var eventDto = _mapper.Map<EventDtoResponse>(await _eventRepository.GetEvent(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<Event>))]
        public async Task<ActionResult<List<Event>>> GetEvents(string name)
        {
            var eventDtos = _mapper.Map<List<EventDtoResponse>>(await _eventRepository.GetEvents(name));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventDtos);
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<EventDtoResponse>>> GetFilteredEvents([FromQuery] List<string> subcategory, [FromQuery] DateTime start, [FromQuery] DateTime end)
        {

            var eventDtos = _mapper.Map<List<EventDtoResponse>>(await _eventRepository
                .FilterEvents(subcategory, start, end));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventDtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddEvent([FromBody] EventDtoRequest eventDtoRequest)
        {
            if (eventDtoRequest == null)
                return BadRequest(ModelState);

            if (eventDtoRequest.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(eventDtoRequest.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in eventDtoRequest.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }
            Event _event = _mapper.Map<Event>(eventDtoRequest);
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
