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
        public AccommodationController(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
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

        [HttpGet("{accommodationId}")]
        [ProducesResponseType(200, Type = typeof(Accommodation))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Event>> GetAccommodation(int accommodationId)
        {
            if (!await _accommodationRepository.AccomodationExists(accommodationId))
                return NotFound(ModelState);
            var events = await _accommodationRepository.GetAccommodation(accommodationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }
    }
}
