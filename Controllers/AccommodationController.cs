﻿using GoTravnikApi.Interfaces;
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
    }
}
