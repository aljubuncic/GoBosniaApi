using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
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
        public AttractionController(IAttractionRepository attractionRepository) {
            _attractionRepository = attractionRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Attraction>))]
        public async Task<ActionResult<List<Attraction>>> GetAttractions()
        {
            var events = await _attractionRepository.GetAttractions();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{attractionId}")]
        [ProducesResponseType(200, Type = typeof(Attraction))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Event>> GetEvent(int attractionId)
        {
            if (!await _attractionRepository.AttractionExists(attractionId))
                return NotFound(ModelState);
            var events = await _attractionRepository.GetAttraction(attractionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }
    }
}
