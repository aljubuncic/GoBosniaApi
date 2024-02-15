using AutoMapper;
using GoTravnikApi.Data;
using GoTravnikApi.Dto;

using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : TouristContentController<Event, EventDtoRequest,  EventDtoResponse>
    {
        private readonly IEventService _eventService;
        private readonly ISubcategoryService _subcategoryService;

        public EventController(IEventService eventService, ISubcategoryService subcategoryService, IRatingService ratingService) : base(eventService, subcategoryService, ratingService)
        {
            _eventService = eventService;
            _subcategoryService = subcategoryService;
        }

        [HttpGet("filter/date")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<EventDtoResponse>>> GetFilteredEventsByDate([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var eventDtoResponses = await _eventService.GetByDateRange(start, end);

            return Ok(eventDtoResponses);
        }

        [HttpGet("filter/subcategories")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<EventDtoResponse>>> GetFilteredEventsBySubcategories([FromQuery] List<string> subcategoryNames)
        {
            var eventDtoResponses = await _eventService.GetBySubcategories(subcategoryNames);

            return Ok(eventDtoResponses);
        }
    }
}
