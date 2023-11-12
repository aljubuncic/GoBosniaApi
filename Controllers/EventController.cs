using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
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
        public EventController(IEventRepository eventRepository) { 
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Event>))]
        public async Task<ActionResult<List<Event>>> GetEvents() 
        {
            var events = await _eventRepository.GetEvents();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(events);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Event))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            if(!await _eventRepository.EventExists(id)) 
                return NotFound(ModelState);
            var events = await _eventRepository.GetEvent(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(List<Event>))]
        public async Task<ActionResult<List<Event>>> GetEvents(string name)
        {
            var events = await _eventRepository.GetEvents(name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

    }
}
