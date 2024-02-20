using AutoMapper;
using GoTravnikApi.Data;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : TouristContentController<Event, EventDtoRequest,  EventDtoResponse>
    {
        private readonly IEventService _eventService;
        private readonly ISubcategoryService _subcategoryService;

        public EventController(IEventService eventService, ISubcategoryService subcategoryService, IRatingService ratingService) 
            : base(eventService, subcategoryService, ratingService, "events")
        {
            _eventService = eventService;
            _subcategoryService = subcategoryService;
        }

        [HttpGet("filter/date")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<EventDtoResponse>>> GetFilteredEventsByDate([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var eventDtoResponses = await _eventService.GetByDateRange(start, end);

            return Ok(eventDtoResponses);
        }
    }
}
